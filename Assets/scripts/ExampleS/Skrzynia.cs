using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skrzynia : MonoBehaviour
{
    // public zeby fields byly widoczne w Unity
    //private pole nie jest modyfikowalne w unity
    // private z adnotacja
    [SerializeField]
    private float speed = 0.1f;
    public float force = 5.0f; //2

    public float force3 = 10.0f; //3
    public Rigidbody rb;

    public Transform from;
    public Transform to;

    // metoda Start() wywo�ywana jest przy inicjalizacji obiektu
    void Start()
    {
        // ustawienie obiektu w pozycji (0, 0, 0)
        //transform.position = new Vector3(0.0f, 0.0f, 0.0f); //1

        rb = GetComponent<Rigidbody>();
        //rb.AddForce(0, 0, force, ForceMode.Impulse); //2

        rb.AddForce(Vector3.up * force3, ForceMode.Impulse); //3k
    }


    // krok rotacji, wyrazony w procentach, o jaki zostanie wykonana rotacja
    // w ka�dej klatce animacji
    private float percentage = 0.01f;

    void Update()
    {
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, percentage);
    }
    void FixedUpdate()
    {
        // sk�adowa y wektora pr�dko�ci
        if (rb.velocity.y == 0)
        {
            // dzia�amy si�� na cia�o A :)
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

    // random object spawner
    // void spawnRandomVector()
    // {
    //     int randomIndex = Random.Range(0, myObjects.Length);
    //     Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 10), 0.5f, Random.Range(0, 10));

    //     if (!positions.Contains(randomSpawnPosition))
    //     {
    //         i++;
    //         Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
    //     }
    // }
}