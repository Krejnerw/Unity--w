using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L6_zadanie1 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    private Vector3 startPoint = new Vector3();
    private Vector3 target = new Vector3();
    public Vector3 destination = new Vector3();

    private bool isRunningForward = true;
    private bool isRunningBackward = false;
    private GameObject oldParent;
    private bool isParentNull = false;

    void Start()
    {
        startPoint = transform.position;
    }

    void Update()
    {
        // if (Equals(transform.position, startPoint))
        // {
        //     Debug.Log("Me reached the destination.");
        //     target = destination;
        //     Debug.Log("New target = start.");
        // }
        if (Equals(transform.position, destination))
        {
            Debug.Log("Me reached the start.");
            target = startPoint;
            Debug.Log("New target = destination.");
        }
        if (isRunning)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * elevatorSpeed);
        }
    }

    // Listing 3 - nie rusza sie razem z platforma
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na me_blue.");
            try
            {
                oldParent.gameObject.transform.parent = other.gameObject.transform.parent;
            }
            catch (NullReferenceException err)
            {
                Debug.Log("Player parent is null");
                isParentNull = true;
            }
            other.gameObject.transform.parent = transform;
            target = destination;
            // if (transform.position == destination)
            // {
            //     target = startPoint;
            //     isRunningBackward = true;
            //     isRunningForward = false;
            // }
            // else if (transform.position == startPoint)
            // {
            //     target = destination;
            //     isRunningForward = true;
            //     isRunningBackward = false;
            // }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z me_blue.");

            // Listing 4 - zmiana własności parent gracza.
            if (isParentNull == true)
            {
                other.gameObject.transform.parent = null;
            }
            else
            {
                other.gameObject.transform.parent = oldParent.transform;
            }
        }
    }
}