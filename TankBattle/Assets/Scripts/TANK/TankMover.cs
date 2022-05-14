using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb;

    //public TankMovementData movementData;

    private Vector2 movementVector;
    
    public TankMovementDate tankMovementDate;
    public float currentSpeed = 0;// tốc độ hiện tại
    public float CurrentForwardDirection = 1;//Hướng chuyển tiếp hiện tại

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);// tính toán tốc độ 
        OnSpeedChange?.Invoke(this.movementVector.magnitude);
        if (movementVector.y > 0)
            CurrentForwardDirection = 1;
        else if (movementVector.y < 0)
            CurrentForwardDirection = -1;
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += tankMovementDate.Acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= tankMovementDate.Deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, tankMovementDate.maxSpeed);
    }

    

    private void FixedUpdate()
    {
        rb.velocity = (Vector2)transform.up * currentSpeed * CurrentForwardDirection * Time.fixedDeltaTime;// lực di chuyển tank
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * tankMovementDate.RotationSpeed * Time.fixedDeltaTime));//xoay tank
    }
}
