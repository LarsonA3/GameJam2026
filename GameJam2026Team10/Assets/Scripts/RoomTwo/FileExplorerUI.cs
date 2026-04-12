using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class FileExplorerUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject explorerPanel;
    public GameObject staffFolderPanel;
    public GameObject dialogPanel;
    public GameObject codePanel;

    [Header("Dialog")]
    public TextMeshProUGUI dialogText;

    [Header("Code")]
    public string code = "2134";
    public TextMeshProUGUI codeDisplay;


    public AudioSource voice;
    private bool hasPlayedVoice = false;

    private static readonly string[] questions =
    {
        "Are you a member of staff?",
        "Are you sure?",
        "Are you not not a staff?",
        "Are you 1000% positive?",
        "Ok, last time. Are you a member of staff?"
    };

    private int dialogStep;
    private PlayerInput playerInput;

    private void Start()
    {
        gameObject.SetActive(false);
        playerInput = FindFirstObjectByType<PlayerInput>();
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            Close();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        dialogStep = 0;
        ShowPanel(explorerPanel);

        if (!hasPlayedVoice) { voice.Play(); }
        hasPlayedVoice = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerInput != null)
        {
            playerInput.actions["Move"].Disable();
            playerInput.actions["Look"].Disable();
            playerInput.actions["Jump"].Disable();
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerInput != null)
        {
            playerInput.actions["Move"].Enable();
            playerInput.actions["Look"].Enable();
            playerInput.actions["Jump"].Enable();
        }
    }
    public void OnClickStaffFolder()
    {
        ShowPanel(staffFolderPanel);
    }

    public void OnClickBack()
    {
        ShowPanel(explorerPanel);
    }

    public void OnClickCodeFile()
    {
        dialogStep = 0;
        ShowDialog();
    }

    public void OnClickYes()
    {
        dialogStep++;
        if (dialogStep >= questions.Length)
            ShowCode();
        else
            ShowDialog();
    }

    public void OnClickNo()
    {
        // Denied — boot them back to the root
        dialogStep = 0;
        ShowPanel(explorerPanel);
    }

    private void ShowDialog()
    {
        ShowPanel(dialogPanel);
        if (dialogText != null)
            dialogText.text = questions[dialogStep];
    }

    private void ShowCode()
    {
        ShowPanel(codePanel);
        if (codeDisplay != null)
            codeDisplay.text = $"Access Code: {code}";
    }

    private void ShowPanel(GameObject panel)
    {
        explorerPanel.SetActive(explorerPanel == panel);
        staffFolderPanel.SetActive(staffFolderPanel == panel);
        dialogPanel.SetActive(dialogPanel == panel);
        codePanel.SetActive(codePanel == panel);
    }
}
