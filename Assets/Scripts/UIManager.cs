using UnityEngine;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject BackgroundOverlay;

    private GameObject currentOpenPanel;

    public static bool InputLocked;

    [Header("Panels")]
    public GameObject settings;
    public GameObject pauseUI;
    public GameObject menu;
    public GameObject title;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPanel(menu);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CloseCurrentPanel();
        }

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     OpenPanel(quest);
        // }


    }

    public void Start()
    {
        TitleScreen();
    }


    public void OpenBackgroundOverlay()
    {
        BackgroundOverlay.SetActive(true);
    }

    public void CloseBackgroundOverlay()
    {
        BackgroundOverlay.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        if (currentOpenPanel != null && currentOpenPanel != panel)
        {
            currentOpenPanel.SetActive(false);
        }

        currentOpenPanel = panel;
        panel.SetActive(true);

        // Reset scale before animating
        panel.transform.localScale = Vector3.zero;

        // Pop-out animation
        panel.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack).SetUpdate(true);

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

    public void StartGame() 
    {
        title.SetActive(false);
        Time.timeScale = 1f;
        BackgroundOverlay.SetActive(false);
        InputLocked = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void TitleScreen()
    {
        title.SetActive(true);

        Time.timeScale = 0f;
        BackgroundOverlay.SetActive(true);
        InputLocked = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
