using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxSpeed;
    private Rigidbody rigidbody;
    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (rigidbody.velocity.magnitude > maxSpeed) {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }
}
