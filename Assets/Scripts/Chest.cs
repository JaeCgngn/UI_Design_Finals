using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public GameObject inventoryPanel;

    public void Interact()
    {
        UIManager.Instance.OpenPanel(inventoryPanel);
    }
}
