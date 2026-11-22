using UnityEngine;
using UnityEngine.InputSystem;

public class RoomDoor : MonoBehaviour
{
    [SerializeField] private ItemId requiredKey;
    [SerializeField] private Transform doorModel;

    private bool playerInside;
    private bool opened;

    private void Update()
    {
        if (!playerInside ||
            opened ||
            Keyboard.current == null ||
            !Keyboard.current.eKey.wasPressedThisFrame)
        {
            return;
        }

        if (InventoryManager.Instance.HasItem(requiredKey))
        {
            opened = true;

            if (doorModel != null)
            {
                doorModel.gameObject.SetActive(false);
            }

            Debug.Log("Room unlocked.");
        }
        else
        {
            Debug.Log("This room is locked.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}