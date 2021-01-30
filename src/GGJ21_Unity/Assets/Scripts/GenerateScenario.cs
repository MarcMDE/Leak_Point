using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateScenario : MonoBehaviour
{
    [SerializeField] int numCubes;
    [SerializeField] float inRadius, outRadius, height;
    [SerializeField] float minScale, maxScale;
    [SerializeField] Vector3 origin;
    [SerializeField] GameObject prefab;

    GameObject[] cubes;

    Transform parent;

    public void Generate()
    {
        if (parent == null)
            parent = new GameObject("Scenario").transform;

        cubes = new GameObject[numCubes];

        for (int i = 0; i < numCubes; i++)
        {
            float degree = Random.Range(0, Mathf.PI * 2);

            /*
            Vector3 pos = new Vector3(  Mathf.Cos(degree) * Random.Range(inRadius, outRadius),
                                        Random.Range(0, height),
                                        Mathf.Sin(degree) * Random.Range(inRadius, outRadius));
            pos += origin;
            */

            float degree2 = Random.Range(0, Mathf.PI);
            Vector3 pos = new Vector3(  Mathf.Cos(degree) * Mathf.Sin(degree2),
                                        Mathf.Sin(degree) * Mathf.Sin(degree2),
                                        Mathf.Cos(degree2));
            
            pos *= Random.Range(inRadius, outRadius);
            pos += origin;


            //Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90)));
            Quaternion rot = Quaternion.Euler(Vector3.zero);

            cubes[i] = Instantiate<GameObject>(prefab, pos, rot, parent);

            Vector3 scale = Vector3.one * Random.Range(minScale, maxScale);

            cubes[i].transform.localScale = scale;

            Vector3 target = new Vector3(origin.x, origin.y, origin.z);
            cubes[i].transform.LookAt(target);



        }

        Debug.Log("Numero de cubos:" + parent.childCount.ToString());
    }

    public void Delete()
    {
        if (parent != null)
            DestroyImmediate(parent.gameObject);
    }
}
