using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skrzynia3 : MonoBehaviour
{
    public float force = 10.0f;
    public Rigidbody rb;

    void Start()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
