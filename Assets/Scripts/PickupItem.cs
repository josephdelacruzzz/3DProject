using UnityEngine;

public class PickupItem : MonoBehaviour {
    [SerializeField] private ItemId itemId;

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) {
            return;
        }
        InventoryManager.Instance.AddItem(itemId);
        Debug.Log("Collected " + itemId);
        gameObject.SetActive(false);
    }
}