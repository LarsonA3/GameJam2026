using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused;
    private PlayerInput playerInput;
    private InputSystem_Actions input;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    private void Start()
    {
        playerInput = FindFirstObjectByType<PlayerInput>();
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (ESC() && !isPaused)
            TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        pausePanel.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (playerInput != null)
        {
            if (isPaused)
            {
                playerInput.actions["Move"].Disable();
                playerInput.actions["Look"].Disable();
                playerInput.actions["Jump"].Disable();
            }
            else
            {
                playerInput.actions["Move"].Enable();
                playerInput.actions["Look"].Enable();
                playerInput.actions["Jump"].Enable();
            }
        }
    }

    public void Resume()
    {
        if (isPaused) TogglePause();
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }

    private bool ESC()
    {
        return input.Player.Pause.IsPressed();
    }
}
