
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// pozycje x oraz z były pobierane adekwatnie dla 
// obiektu platformy, do której skrypt jest dołączany 
// (zakładamy, że tak będzie),
public class zadanie4_1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int spwanObjNum = 10;
    int objectCounter = 0;
    private int i = 0;
    // obiekt do generowania
    public GameObject block;
    public Material[] materials;
    Vector3 planeXYZ;
    Vector3 planeSize;

    void Start()
    {
        planeXYZ = gameObject.transform.position;
        // planeSize = gameObject.transform.bounds.size;
        planeSize = GetComponent<Renderer>().bounds.size;

        // nie robie tym rozwiązaniem bo pozwala na tylko 1 objekt w dalej lini x i z

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        // List<int> pozycje_x = new List<int>(Enumerable.Range((int)(planeXYZ.x - planeScale.x * 5) + 1, 20).OrderBy(x => Guid.NewGuid()).Take(spwanObjNum));
        // List<int> pozycje_z = new List<int>(Enumerable.Range((int)(planeXYZ.z - planeScale.z * 5) + 1, 20).OrderBy(z => Guid.NewGuid()).Take(spwanObjNum));
        // List<int> pozycje_x = new List<int>(Enumerable.Range(-10, 20).OrderBy(x => Guid.NewGuid()).Take(spwanObjNum));
        // List<int> pozycje_z = new List<int>(Enumerable.Range(-10, 20).OrderBy(x => Guid.NewGuid()).Take(spwanObjNum));

        // for (int i = 0; i < spwanObjNum; i++)
        // {
        //     this.positions.Add(new Vector3(pozycje_x[i], planeXYZ.y + 0.5f, pozycje_z[i]));
        // }

        // sprawdza sie dla obiektów 1x1
        // if (spwanObjNum > (planeSize.x * 9 + 1) * (planeSize.z * 9 + 1))
        if (spwanObjNum > (planeSize.x - 1) * (planeSize.z - 1))
        {
            throw new System.Exception("can't create so many objects");
        }
        while (i != spwanObjNum)
        {
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range((int)(planeXYZ.x - planeSize.x / 2) + 1, (int)(planeXYZ.x + planeSize.x / 2)),
                planeXYZ.y + 0.5f,
                Random.Range((int)(planeXYZ.z - planeSize.z / 2) + 1, (int)(planeXYZ.z + planeSize.z / 2)));

            if (!positions.Contains(randomSpawnPosition))
            {
                i++;
                positions.Add(randomSpawnPosition);
            }
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem.ToString());
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            // Debug.Log(pos.ToString());
            int randomIndex = Random.Range(0, materials.Length);
            this.block.GetComponent<Renderer>().material = materials[randomIndex];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
