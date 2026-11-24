using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour {
    [SerializeField] private Light flashlight;

    private void Update() {
        if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame) {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}