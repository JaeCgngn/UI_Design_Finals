using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public float interactDistance = 3f;
    public GameObject equipUI;
    public GameObject interactUI;

    private IInteractable currentInteractable;
    private IEquipable currentEquipable;

    public GameObject itemEquippedUI;

    void Update()
    {
        CheckTarget();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentEquipable != null)
            {
                currentEquipable.Equip();
            }
            else if (currentInteractable != null)
            {
                currentInteractable.Interact();
            }
        }
    }

    void CheckTarget()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        currentEquipable = null;
        currentInteractable = null;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            currentEquipable = hit.collider.GetComponent<IEquipable>();
            currentInteractable = hit.collider.GetComponent<IInteractable>();
        }

        equipUI.SetActive(currentEquipable != null);
        interactUI.SetActive(currentInteractable != null && currentEquipable == null);
    }

}
