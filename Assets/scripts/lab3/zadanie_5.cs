using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_5 : MonoBehaviour
{
    public GameObject[] myObjects;
    private List<Vector3> positions = new List<Vector3>();
    private int i = 0;

    void Start()
    {
        while (i != 10)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 10), 0.5f, Random.Range(0, 10));

            if (!positions.Contains(randomSpawnPosition))
            {
                i++;
                Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            }
        }

    }
}
