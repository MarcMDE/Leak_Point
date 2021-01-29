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

            Vector3 pos = new Vector3(  Mathf.Cos(degree) * Random.Range(inRadius, outRadius),
                                        Random.Range(0, height),
                                        Mathf.Sin(degree) * Random.Range(inRadius, outRadius));

            pos += origin;

            Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90)));

            cubes[i] = Instantiate<GameObject>(prefab, pos, rot, parent);

            Vector3 scale = Vector3.one * Random.Range(minScale, maxScale);

            cubes[i].transform.localScale = scale;
        }
    }

    public void Delete()
    {
        if (parent != null)
            DestroyImmediate(parent.gameObject);
    }
}
