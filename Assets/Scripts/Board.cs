using UnityEngine;

public class Board : MonoBehaviour, IInteractable
{
    public GameObject questPanel;

    public void Interact()
    {
        UIManager.Instance.OpenPanel(questPanel);
    }
}
