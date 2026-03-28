using UnityEngine;

public class Board : MonoBehaviour, IInteractable
{
    public GameObject questPanel;

    public void Interact()
    {
        UIManager.Instance.OpenPanel(questPanel);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            UIManager.Instance.CloseCurrentPanel();
        }
    }
}
