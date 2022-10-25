using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_3 : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 endPosition;
    private int i = 0;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        endPosition = transform.position;
        endPosition.x += 10;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * speed);
        if (transform.position == endPosition)
        {
            i++;
            transform.Rotate(new Vector3(0, 90, 0), Space.World);
            if (i == 1)
            {
                endPosition.z -= 10;
            }
            else if (i == 2)
            {
                endPosition.x -= 10;
            }
            else if (i == 3)
            {
                endPosition.z += 10;
            }
            else if (i == 4)
            {
                i = 0;
                endPosition.x += 10;
            }

        }
    }
}
