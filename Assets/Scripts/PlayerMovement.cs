using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 verticalVelocity;

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }

    private void Update(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;
        movement = movement.normalized;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        controller.Move(movement * currentSpeed * Time.deltaTime);

        if (controller.isGrounded && verticalVelocity.y < 0){
            verticalVelocity.y = -2f;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
}