using UnityEngine;

public class EquipItem : MonoBehaviour, IEquipable
{
    public Transform equipPoint;

    private InteractManager interactManager;

    public void Equip()
    {
        Debug.Log("Item Equipped!");
        Destroy(gameObject);
        interactManager = FindFirstObjectByType<InteractManager>();
        if (interactManager != null)
        {
            interactManager.itemEquippedUI.SetActive(true);
        }

    }
}

