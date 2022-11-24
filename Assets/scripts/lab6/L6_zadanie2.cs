using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L6_zadanie2 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public List<Vector3> positions = new List<Vector3>();
    private Vector3 target = new Vector3();

    void Start()
    {
        positions.Insert(0, transform.position);
    }

    void Update()
    {
        if (isRunning)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * elevatorSpeed);
        }
        if (Equals(transform.position, target))
        {
            isRunning = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = positions[1];
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = positions[0];
            isRunning = true;
        }
    }
}