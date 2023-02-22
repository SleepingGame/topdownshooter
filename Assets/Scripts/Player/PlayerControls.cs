using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    
    public float playerSpeed = 2.0f, jumpHeight = 1.0f, gravityValue = -9.81f;
    bool groun, jump;
    
    CharacterController controller;
    Vector3 plVel;
    Vector2 moveInput;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }    
    
    public void Jump(InputAction.CallbackContext context)
    {
        jump = context.action.triggered;
    }

    void Update()
    {
        groun = controller.isGrounded;
        if (groun && plVel.y < 0)
        {
            plVel.y = 0f;
        }

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (jump && groun)
        {
            plVel.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        plVel.y += gravityValue * Time.deltaTime;
        controller.Move(plVel * Time.deltaTime);
    }
}
