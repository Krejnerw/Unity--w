using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L6_zadanie3 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    private Vector3 target = new Vector3();
    public List<Vector3> positions = new List<Vector3>();

    private GameObject oldParent;
    private bool isParentNull = false;
    private bool isRunningForward = true;
    private bool isRunningBackward = false;

    private int count = 1;
    private int tmp = 1;

    void Start()
    {
        positions.Insert(0, transform.position);
    }

    void Update()
    {
        if (Equals(transform.position, target))
        {
            Debug.Log("Me reached the point.");
            Debug.Log("count");
            if (isRunningForward && count == positions.Count - 1)
            {
                Debug.Log("To the begiiiining.");
                tmp = -1;
                isRunningBackward = true;
                isRunningForward = false;
            }
            // else if (isRunningBackward && count == 0)
            // {
            //     Debug.Log("To theeee eeeend.");
            //     tmp = 1;
            //     isRunningBackward = false;
            //     isRunningForward = true;
            // }
            if (count != 0)
            {
                count += tmp;
                Debug.Log("Check at.");
                Debug.Log(count);
                target = positions[count];
            }
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
            Debug.Log("Player wszedł na me_pink.");
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
            target = positions[0];
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
            Debug.Log("Player zszedł z me_pink.");

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