using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movementVector;
    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    [SerializeField]  public float movementSmoothness = 0.1f; // How heavy/smooth the tank feels

    private Vector2 currentVelocity = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleShoot()
    {
        Debug.Log("Shooting test");
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    private void FixedUpdate()
    {
        // Target velocity based on current forward direction
        Vector2 targetVelocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;


        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, movementSmoothness);
        rb.velocity = currentVelocity;

        // Rotate tank based on horizontal input
        float rotationAmount = -movementVector.x * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation + rotationAmount);
    }
}
