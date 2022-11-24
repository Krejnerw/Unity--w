using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L6_zadanie5 : MonoBehaviour
{
    // private Rigidbody _rigidbody;
    void Start()
    {
        // _rigidbody = this.GetComponent<Rigidbody>();
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Enemy"))
    //     {
    //         Debug.Log("Ugh i touched the enemy aaaaa.");
    //     }
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Ugh i touched the enemy aaaaa.");
        }
    }
}
