using UnityEngine;

public class RandomTip : MonoBehaviour
{
    private void OnEnable()
    {
        // disable all children first
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);

        // pick one and enable it
        int pick = Random.Range(0, transform.childCount);
        transform.GetChild(pick).gameObject.SetActive(true);
    }
}