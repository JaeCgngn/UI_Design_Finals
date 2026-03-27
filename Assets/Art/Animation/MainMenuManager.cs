using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneController.Instance.LoadLevelByName("MainSCN");
    }
}
