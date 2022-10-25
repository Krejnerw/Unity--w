using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRotateAround : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
    public float force = 5.0f; //2

    public float force3 = 10.0f; //3
    public Rigidbody rb;

    public Transform from;
    public Transform to;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // krok rotacji, wyrazony w procentach, o jaki zostanie wykonana rotacja
    // w ka�dej klatce animacji
    private float percentage = 0.01f;

    void Update()
    {
        // transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, percentage);
        // transform.RotateAround(transform.position, Vector3.up, 90 * Time.deltaTime);
        transform.Rotate(new Vector3(0, 90, 0), Space.World);
        // Vector3 tmp = transform.position;
        // tmp.y = 90;
        // transform.Rotate(tmp, Space.World);
    }
    // void FixedUpdate()
    // {
    //     // sk�adowa y wektora pr�dko�ci
    //     if (rb.velocity.y == 0)
    //     {
    //         // dzia�amy si�� na cia�o A :)
    //         rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    //     }
    // }
}
