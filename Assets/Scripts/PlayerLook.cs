using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float sensitivity = 0.08f;
    [SerializeField] private float minimumPitch = -85f;
    [SerializeField] private float maximumPitch = 85f;

    private float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Mouse.current == null)
        {
            return;
        }

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float yaw = mouseDelta.x * sensitivity;
        float verticalLook = mouseDelta.y * sensitivity;

        pitch -= verticalLook;
        pitch = Mathf.Clamp(pitch, minimumPitch, maximumPitch);

        transform.Rotate(Vector3.up * yaw);

        if (cameraPivot != null)
        {
            cameraPivot.localRotation =
                Quaternion.Euler(pitch, 0f, 0f);
        }
    }
}