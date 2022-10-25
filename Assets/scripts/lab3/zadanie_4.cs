using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_4 : MonoBehaviour
{
    public float speed = 2.0f;
    public float rotationSpeed;

    void Update()
    {

    }
    void FixedUpdate()
    {
        // pobranie wartości zmiany pozycji w danej osi
        // wartości są z zakresu [-1, 1]
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(mH, 0, mV);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            transform.right = movementDirection;
        }
    }
}
