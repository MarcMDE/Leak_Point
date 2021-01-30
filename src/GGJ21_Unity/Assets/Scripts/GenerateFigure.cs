using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFigure : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] int layers;
    [SerializeField] GameObject prefab;

    Transform parent;

    const int size = 9;


    bool[,] h = new bool [,]{   {false,false,false,false,false,false,false,false,false},
                                {false,false,true,false,false,false,true,false,false},
                                {false,false,true,false,false,false,true,false,false},
                                {false,false,true,false,false,false,true,false,false},
                                {false,false,true,true,true,true,true,false,false},
                                {false,false,true,false,false,false,true,false,false},
                                {false,false,true,false,false,false,true,false,false},
                                {false,false,true,false,false,false,true,false,false},
                                {false,false,false,false,false,false,false,false,false}};



    void Start()
    {
        parent = new GameObject("Figure").transform;

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if (h[y, x])
                {
                    for (int i = 0; i < layers; i++)
                    {
                        float z = Random.Range(30, 125);
                        Vector3 vPos = new Vector3(x / (float)size, y / (float)size, z);
                        Vector3 wPos = camera.ViewportToWorldPoint(vPos);
                        GameObject c = Instantiate<GameObject>(prefab, wPos, Quaternion.identity, parent);
                        float scale = Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2) * z * 2 * 0.1f;
                        c.transform.localScale = Vector3.one * scale;

                        Vector3 target = new Vector3(0, wPos.y, 0);
                        c.transform.LookAt(target);

                    }
                }
            }
        }
        Vector3 cbPos = camera.ViewportToWorldPoint(new Vector3(0.5f,0.5f,-5));
        GameObject cb = Instantiate<GameObject>(prefab, cbPos, Quaternion.identity, parent);
        cb.transform.localScale = Vector3.one * 10;
        Vector3 target2 = new Vector3(0, cbPos.y, 0);
        cb.transform.LookAt(target2);

        //Destroy(camera);
    }


    void Update()
    {
        
    }
}
