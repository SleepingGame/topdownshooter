using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerCon controller;
    private Camera mainCamera;

    private void Start()
    {
        controller = GetComponent<PlayerCon>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementInput = new Vector2(horizontalInput, verticalInput);
        controller.SetMovementInput(movementInput);

        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(mouseRay, out float rayDistance))
        {
            Vector3 pointToLook = mouseRay.GetPoint(rayDistance);
            pointToLook.y = transform.position.y; // here im keeping the y position of the player

            transform.LookAt(pointToLook);
        }
    }
}
