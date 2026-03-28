using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public GameObject inventoryPanel;

    public void Interact()
    {
        UIManager.Instance.OpenPanel(inventoryPanel);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.C)) 
        {
            UIManager.Instance.CloseCurrentPanel();
        }
    }
}
