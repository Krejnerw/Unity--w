using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public float distancePerFrame;

    void Update()
    {
        transform.Translate(0, 0, distancePerFrame);
    }
}
