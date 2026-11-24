using UnityEngine;
using UnityEngine.InputSystem;

public class KeyCraft : MonoBehaviour {
    [SerializeField] private GameObject craftedKeyObject;
    [SerializeField] private ItemId handleItem = ItemId.KeyHandle;
    [SerializeField] private ItemId bladeItem = ItemId.KeyBlade;
    [SerializeField] private ItemId teethItem = ItemId.KeyTeeth;

    private bool playerInRange;
    private bool keyCrafted;

    private void Start() {
        if (craftedKeyObject != null) {
            craftedKeyObject.SetActive(false);
        }
    }

    private void Update() {
        if (!playerInRange || keyCrafted) {
            return;
        }

        if (Keyboard.current == null) {
            return;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame){
            CraftKey();
        }
    }

    private void OnTriggerEnter(Collider other){
        if (!other.CompareTag("Player")){
            return;
        }
        playerInRange = true;
        Debug.Log("Press E to craft the GateKey.");
    }

    private void OnTriggerExit(Collider other){
        if (!other.CompareTag("Player")){
            return;
        }
        playerInRange = false;
    }

    private void CraftKey(){
        InventoryManager inventory = InventoryManager.Instance;

        if (inventory == null) {
            Debug.LogError("InventoryManager could not be found.");
            return;
        }

        bool hasHandle = inventory.HasItem(handleItem);
        bool hasBlade = inventory.HasItem(bladeItem);
        bool hasTeeth = inventory.HasItem(teethItem);

        if (!hasHandle || !hasBlade || !hasTeeth) {
            Debug.Log("You need the handle, blade, and teeth before crafting the GateKey.");
            return;
        }

        if (craftedKeyObject != null) {
            craftedKeyObject.SetActive(true);
        }

        keyCrafted = true;

        Debug.Log("The three key pieces were combined.");
        Debug.Log("The GateKey has spawned on the crafting table.");
    }
}