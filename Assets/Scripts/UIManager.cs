using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject BackgroundOverlay;

    private GameObject currentOpenPanel;

    public static bool InputLocked;

    [Header("Panels")]
    public GameObject settings;
    public GameObject pauseUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            OpenPanel(settings);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CloseCurrentPanel();
        }
           


    }




    public void OpenBackgroundOverlay()
    {
        BackgroundOverlay.SetActive(true);
    }

    public void CloseBackgroundOverlay()
    {
        BackgroundOverlay.SetActive(false);
    }

    public void OpenPanel(GameObject panel) // Call this to open any panel, it will automatically close the currently open one
    {
        if (currentOpenPanel != null && currentOpenPanel != panel) // Close current panel if it's different from the one being opened
        {
            currentOpenPanel.SetActive(false);
        }
        currentOpenPanel = panel;
        panel.SetActive(true);
        Time.timeScale = 0f;
        BackgroundOverlay.SetActive(true);
        InputLocked = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseCurrentPanel() // Call this to close whatever panel is currently open
    {
        if (currentOpenPanel != null)
        {
            currentOpenPanel.SetActive(false);
            currentOpenPanel = null;
        }
        Time.timeScale = 1f;
        BackgroundOverlay.SetActive(false);
        InputLocked = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
