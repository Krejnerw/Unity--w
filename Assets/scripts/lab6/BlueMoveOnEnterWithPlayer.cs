using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMoveOnEnterWithPlayer : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    private Vector3 startPoint = new Vector3();
    private Vector3 target = new Vector3();
    private Vector3 destination = new Vector3();
    public float x;
    public float y;
    public float z;

    private bool isRunningForward = true;
    private bool isRunningBackward = false;
    private GameObject oldParent;
    private bool isParentNull = false;

    void Start()
    {
        startPoint = transform.position;
        destination = new Vector3(x, y, z);
    }

    void Update()
    {
        if (isRunningForward && Equals(transform.position, startPoint))
        {
            isRunning = false;
        }
        else if (isRunningBackward && Equals(transform.position, destination))
        {
            isRunning = false;
        }
        if (isRunning)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * elevatorSpeed);
        }
    }

    // TO DO - fix problem with player is not moving with platform
    // addings parenting is changing
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
            if (transform.position == destination)
            {
                Debug.Log("Me reached the start.");
                target = startPoint;
                Debug.Log("New target = destination.");
                isRunningBackward = true;
                isRunningForward = false;
            }
            else if (transform.position == startPoint)
            {
                Debug.Log("Me reached the destination.");
                target = destination;
                Debug.Log("New target = start.");
                isRunningForward = true;
                isRunningBackward = false;
            }
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