using UnityEngine;

public class EquipItem : MonoBehaviour, IInteractable
{
    public Transform equipPoint;

    private InteractManager interactManager;

    public void Interact()
    {
        // Equip();
        Debug.Log("Item Interact!");
        Destroy(gameObject);
        interactManager = FindFirstObjectByType<InteractManager>();
        if (interactManager != null)
        {
            interactManager.itemEquippedUI.SetActive(true);
        }
        

    }

    // void Equip()
    // {
    //     transform.SetParent(equipPoint);
    //     transform.localPosition = Vector3.zero;
    //     transform.localRotation = Quaternion.identity;

    //     Debug.Log("Item equipped!");
    // }


}

