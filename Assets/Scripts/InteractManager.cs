using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public float interactDistance = 3f;
    public GameObject interactUI;

    private IInteractable currentInteractable;

    public GameObject itemEquippedUI;

    void Update()
    {
        CheckInteraction();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactUI.SetActive(true);
                currentInteractable = interactable;
                return;
            }
        }

        interactUI.SetActive(false);
        currentInteractable = null;
    }

}
