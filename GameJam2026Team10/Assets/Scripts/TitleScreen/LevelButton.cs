using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}