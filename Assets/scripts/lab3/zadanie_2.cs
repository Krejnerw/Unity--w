using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_2 : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 target;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        endPosition = transform.position;
        endPosition.x = 10;
        target = endPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == endPosition)
        {
            target = startPosition;
        }
        else if (transform.position == startPosition)
        {
            target = endPosition;
        }
    }
}
