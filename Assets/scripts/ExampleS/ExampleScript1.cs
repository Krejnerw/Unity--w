using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript1 : MonoBehaviour
{
    public float distancePerSecond;

    void Update()
    {
        transform.Translate(0, 0, distancePerSecond * Time.deltaTime);
    }
}

