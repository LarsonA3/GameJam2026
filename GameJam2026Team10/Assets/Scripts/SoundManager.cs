using UnityEngine;
using System.Collections.Generic;

public enum SoundType
{
    Footsteps,
    GrabBlock,
    LaserShot,
    ButtonPress,
}

public class SoundCollection
{
    private AudioClip[] clips;
    private int lastClipIndex;

    public SoundCollection(params string[] clipNames)
    {
        clips = new AudioClip[clipNames.Length];

        for (int i = 0; i < clipNames.Length; i++)
        {
            clips[i] = Resources.Load<AudioClip>(clipNames[i]);

            if (clips[i] == null)
            {
                Debug.LogError("Invalid clip: " + clipNames[i]);
            }
        }
    }

    public AudioClip GetRandClip()
    {
        if (clips.Length == 0)
        {
            Debug.LogWarning("Must have at least 1 clip");
            return null;
        }
        else if (clips.Length == 1)
        {
            return clips[0];
        }
        else
        {
            int index = lastClipIndex;

            while (index == lastClipIndex)
            {
                index = Random.Range(0, clips.Length);
            }

            lastClipIndex = index;
            return clips[index];
        }
    }
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public float mainVolume = 1.0f;
    private Dictionary<SoundType, SoundCollection> soundMap;
    private AudioSource audioSrc;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        audioSrc = GetComponent<AudioSource>();

        soundMap = new Dictionary<SoundType, SoundCollection>()
        {
            { SoundType.Footsteps, new SoundCollection("footstep") },
            { SoundType.LaserShot, new SoundCollection("laser") },
            { SoundType.ButtonPress, new SoundCollection("button") },
        };
    }

    public static void Play(SoundType type, AudioSource audioSrc = null, float pitch = -1, float volume = 1)
    {
        if (Instance == null)
        {
            return;
        }

        if (Instance.soundMap.ContainsKey(type))
        {
            audioSrc ??= Instance.audioSrc;

            AudioClip clip = Instance.soundMap[type].GetRandClip();
            if (clip == null)
            {
                return;
            }

            audioSrc.pitch = pitch >= 0 ? pitch : Random.Range(0.75f, 1.25f);
            audioSrc.volume = Instance.mainVolume;
            audioSrc.PlayOneShot(clip);
        }
    }
}
