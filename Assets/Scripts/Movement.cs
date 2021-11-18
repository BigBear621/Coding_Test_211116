using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody body;
    float moveInputZ;
    float moveInputX;
    Vector3 moveVector;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    void Update()
    {
        moveInputZ = Input.GetAxisRaw("Vertical");
        moveInputX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        moveVector.z = moveInputZ;
        moveVector.x = moveInputX;
        moveVector.Normalize();
        body.MovePosition(transform.position + (moveVector * 0.1f));
    }
}
