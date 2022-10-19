using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skrzynia4 : MonoBehaviour
{
    public float force = 10.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // sk�adowa y wektora pr�dko�ci
        if (rb.velocity.y == 0)
        {
            // dzia�amy si�� na cia�o A :)
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
