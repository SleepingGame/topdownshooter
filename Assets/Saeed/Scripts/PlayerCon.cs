using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCon : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    private Vector3 movementInput;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = movementInput.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movement);
    }

    public void SetMovementInput(Vector2 input)
    {
        movementInput = new Vector3(input.x, 0f, input.y);
    }
}