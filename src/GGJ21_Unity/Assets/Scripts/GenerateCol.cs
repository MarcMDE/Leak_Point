using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateCol : MonoBehaviour
{
    [SerializeField] int cubesLayer;
    [SerializeField] float height;
    [SerializeField] float sizeBlockMin;
    [SerializeField] float sizeBlockMax;
    [SerializeField] float offsetX;
    [SerializeField] float offsetZ;

    [SerializeField] Vector3 origin;
    [SerializeField] GameObject prefab;

    GameObject[] cubes;

    [SerializeField] Transform grandParent;
    Transform parent;
    public void Generate()
    {
        parent = new GameObject("parent").transform;
        parent.transform.parent = grandParent;

        float actualHeight = 0;

        //cubes = new GameObject[];

        while(actualHeight < height)
        {
            //float degree = Random.Range(0, Mathf.PI * 2);

            float size= Random.Range(sizeBlockMin,sizeBlockMax);
            Vector3 pos = new Vector3(  Random.Range(-offsetX/2, offsetX/2),
                                        size/2 + actualHeight,
                                        Random.Range(-offsetZ/2, offsetZ/2));

            actualHeight += size;
            
            //pos *= Random.Range(inRadius, outRadius);
            pos += origin;


            Quaternion rot = Quaternion.Euler(new Vector3(0, Random.Range(0, 90), 0));

            var cube = Instantiate<GameObject>(prefab, pos, rot, parent);
            Vector3 scale = Vector3.one * size;
            cube.transform.localScale = scale;

        }

    }

    public void Delete()
    {
        if (parent != null)
            DestroyImmediate(parent.gameObject);
    }
}
