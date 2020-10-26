﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10f;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    PhysicMaterial stoppingPhysicsMaterial, movingPhysicsMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);

        collider.material = inputDirection.magnitude > 0 ? movingPhysicsMaterial : stoppingPhysicsMaterial;

        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(inputDirection * accelerationForce, ForceMode.Acceleration);
        }
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");


    }
}