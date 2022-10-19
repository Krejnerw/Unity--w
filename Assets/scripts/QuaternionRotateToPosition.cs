using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRotateToPosition : MonoBehaviour
{
    public Transform from;
    public Transform to;

    // krok rotacji, wyrazony w procentach, o jaki zostanie wykonana rotacja
    // w ka�dej klatce animacji
    private float percentage = 0.01f;

    void Update()
    {
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, percentage);
    }
    //    public void Update
    //    {
    //         cube1.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    //         cube2.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
    //     }
}
