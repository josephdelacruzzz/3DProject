using UnityEngine;

public class ExitGate : MonoBehaviour
{
    [SerializeField] private Collider gateBlocker;
    [SerializeField] private GameObject gateVisual;

    private bool gateOpened;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (gateOpened)
        {
            return;
        }

        InventoryManager inventory = InventoryManager.Instance;

        if (inventory != null && inventory.HasItem(ItemId.GateKey))
        {
            OpenGate();
        }
        else
        {
            Debug.Log("The exit gate is locked. You need the completed GateKey.");
        }
    }

    private void OpenGate()
    {
        gateOpened = true;

        if (gateBlocker != null)
        {
            gateBlocker.enabled = false;
        }

        if (gateVisual != null)
        {
            gateVisual.SetActive(false);
        }

        Debug.Log("The GateKey unlocked the exit gate.");
        Debug.Log("The player can escape the maze.");
    }
}