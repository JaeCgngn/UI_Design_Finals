using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Equip();
        Debug.Log("Item Interact!");
    }
}
