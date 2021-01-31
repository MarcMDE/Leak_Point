using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFigure : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] int layers;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform grandParent;
    [SerializeField] Figure figure;
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;

    GameMaster gameMaster;

    Transform parent;

    const int size = 20;


    bool[,] h = new bool [,]{   /*{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,true,true,false,false,false,false,false,true,true,false,false,false,false,false,true,true,false,false},
                                {false,false,false,true,true,false,false,false,false,true,true,false,false,false,false,true,true,false,false,false},
                                {false,false,false,false,true,true,false,false,false,true,true,false,false,false,true,true,false,false,false,false},
                                {false,false,false,false,false,true,true,true,false,true,true,false,true,true,true,false,false,false,false,false},
                                {false,false,false,false,false,false,true,true,true,true,true,true,true,true,false,false,false,false,false,false},
                                {false,false,false,false,false,false,true,true,true,true,true,true,true,true,false,false,false,false,false,false},
                                {false,false,false,false,false,true,true,true,false,true,true,false,true,true,true,false,false,false,false,false},
                                {false,false,false,false,true,true,false,false,false,true,true,false,false,false,true,true,false,false,false,false},
                                {false,false,false,true,true,false,false,false,false,true,true,false,false,false,false,true,true,false,false,false},
                                {false,false,true,true,false,false,false,false,false,true,true,false,false,false,false,false,true,true,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false}*/
                                
                                /*
                                {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,true,true,true,true,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,true,true,false,false,false,false,true,true,false,false,false,false,false,false},
                                {false,false,false,false,true,true,false,false,false,false,false,false,false,false,true,true,false,false,false,false},
                                {false,false,false,true,false,false,false,false,false,false,false,false,false,false,false,false,true,false,false,false},
                                {false,false,true,false,false,false,false,true,true,true,true,true,false,true,false,false,true,false,false,false},
                                {false,false,true,false,false,false,true,true,false,false,false,true,true,true,false,false,true,false,false,false},
                                {false,false,true,false,false,false,true,false,false,false,false,false,false,true,false,true,true,false,false,false},
                                {false,false,true,false,false,false,true,false,false,false,false,false,false,true,true,true,true,false,false,false},
                                {false,false,true,false,false,false,true,false,false,false,false,false,false,true,true,false,false,false,false,false},
                                {false,false,true,false,false,false,true,false,false,false,false,false,false,true,true,false,false,false,false,false},
                                {false,false,true,false,false,false,true,true,false,false,false,false,true,true,false,false,false,false,false,false},
                                {false,false,true,false,false,false,false,true,true,true,true,true,true,false,false,false,true,false,false,false},
                                {false,false,false,true,false,false,false,false,false,false,false,false,false,false,false,false,true,false,false,false},
                                {false,false,false,false,true,true,false,false,false,false,false,false,false,false,true,true,false,false,false,false},
                                {false,false,false,false,false,false,true,true,false,false,false,false,true,true,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,true,true,true,true,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false}
                                */
                                /*
                                {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
                                {false,false,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,false,false},
                                {false,false,true,true,false,false,false,false,false,false,false,false,false,false,false,false,true,true,false,false},
                                {false,false,false,true,false,false,false,false,false,false,false,false,false,false,false,false,true,false,false,false},
                                {false,false,false,true,true,false,false,false,false,false,false,false,false,false,false,true,true,false,false,false},
                                {false,false,false,false,true,false,false,false,false,false,false,false,false,false,false,true,false,false,false,false},
                                {false,false,false,false,true,true,false,false,false,false,false,false,false,false,true,true,false,false,false,false},
                                {false,false,false,false,false,true,false,false,false,false,false,false,false,false,true,false,false,false,false,false},
                                {false,false,false,false,false,true,true,false,false,false,false,false,false,true,true,false,false,false,false,false},
                                {false,false,false,false,false,false,true,false,false,false,false,false,false,true,false,false,false,false,false,false},
                                {false,false,false,false,false,false,true,true,false,false,false,false,true,true,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,true,false,false,false,false,true,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,true,true,false,false,true,true,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,true,false,false,true,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,true,true,true,true,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
                                {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false}
*/
                               /* {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, true, true, true, true, true, false, false, false, false, false, false, true, true, true, true, true, false, false},
                                {false, true, true, true, true, true, true, false, false, false, false, false, true, true, true, true, true, true, true, false},
                                {false, true, true, false, false, false, true, true, false, false, false, false, true, true, false, false, false, false, true, false},
                                {false, true, false, false, false, false, false, true, false, false, false, true, true, false, false, false, false, false, true, false},
                                {true, true, false, false, false, false, false, true, true, false, false, true, true, false, false, false, false, false, true, true},
                                {true, true, false, false, false, false, false, true, true, false, false, true, false, false, false, false, false, false, true, true},
                                {true, false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, false, true, true, false, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, false, true, true, false, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, false, true},
                                {true, true, false, false, false, false, false, true, true, false, false, true, true, false, false, false, false, false, true, true},
                                {false, true, true, false, false, false, true, true, true, false, false, true, true, true, false, false, false, true, true, false},
                                {false, true, true, false, false, false, true, true, false, false, false, false, true, true, false, false, false, true, true, false},
                                {false, false, true, true, true, true, true, true, false, false, false, false, true, true, true, true, true, true, true, false},
                                {false, false, true, true, true, true, true, false, false, false, false, false, false, true, true, true, true, true, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false}
*/
                               /* {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, true, true, true, true, true, false, false, false, false, false, false, true, true, true, true, true, false, false},
                                {false, true, true, true, true, true, true, false, false, false, false, false, true, true, true, true, true, true, true, false},
                                {false, true, true, false, false, false, true, true, false, false, false, false, true, true, false, false, false, false, true, false},
                                {false, true, false, false, false, false, false, true, false, false, false, true, true, false, false, false, false, false, true, false},
                                {true, true, false, false, false, false, false, true, true, false, false, true, true, false, false, false, false, false, true, true},
                                {true, true, false, false, false, false, false, true, true, false, false, true, false, false, false, false, false, false, true, true},
                                {true, false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, false, true, true, false, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, false, true, true, false, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false, true},
                                {true, false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, false, true},
                                {true, true, false, false, false, false, false, true, true, false, false, true, true, false, false, false, false, false, true, true},
                                {false, true, true, false, false, false, true, true, true, false, false, true, true, true, false, false, false, true, true, false},
                                {false, true, true, false, false, false, true, true, false, false, false, false, true, true, false, false, false, true, true, false},
                                {false, false, true, true, true, true, true, true, false, false, false, false, true, true, true, true, true, true, true, false},
                                {false, false, true, true, true, true, true, false, false, false, false, false, false, true, true, true, true, true, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false}*/

                                /*{false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, true, false},
                                {false, false, false, false, false, false, true, true, true, false, false, false, true, true, true, false, false, true, false, false},
                                {false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, true, false, false, false},
                                {false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, true, true, false, false, false},
                                {false, false, false, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false},
                                {false, false, true, true, false, false, false, false, false, false, false, false, false, true, false, false, false, true, true, false},
                                {false, false, true, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false},
                                {false, false, true, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false},
                                {false, false, true, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, false},
                                {false, false, true, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, true, false},
                                {false, false, true, true, false, false, false, false, true, false, false, false, false, false, false, false, false, true, true, false},
                                {false, false, true, true, false, false, false, true, false, false, false, false, false, false, false, false, false, true, true, false},
                                {false, false, false, true, false, false, true, false, false, false, false, false, false, false, false, false, false, true, false, false},
                                {false, false, false, false, true, true, false, false, false, false, false, false, false, false, false, false, true, false, false, false},
                                {false, false, false, false, true, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false},
                                {false, false, false, true, false, false, true, true, true, false, false, false, true, true, true, false, false, false, false, false},
                                {false, false, true, false, false, false, false, true, true, true, true, true, true, true, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false}*/

                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, true, false, false, false, false},
                                {false, false, false, false, false, false, true, false, true, true, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, true, true, false, true, false, false, false, false, true, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false},
                                {false, false, false, false, true, false, false, false, true, false, false, false, true, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, true, true, false, false, true, true, true, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false},
                                {false, false, false, false, false, false, false, true, false, false, false, true, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false}


          };



    void Start()
    {
       gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }
    public void Generate()
    {
        parent = new GameObject("parent").transform;
        parent.transform.parent = grandParent;
        float AR = 1/camera.aspect;

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if (h[y, x])
                {
                    for (int i = 0; i < layers; i++)
                    {
                        float z = Random.Range(minDistance, maxDistance);
                        Vector3 vPos = new Vector3((1-AR)/2 + AR*( x / (float)size), (size-y-1) / (float)size, z);
                        Vector3 wPos = camera.ViewportToWorldPoint(vPos);
                        GameObject c = Instantiate<GameObject>(prefab, wPos, Quaternion.identity, parent);
                        float scale = Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2) * z * 2 * 1f/size;
                        c.transform.localScale = Vector3.one * scale;

                        Vector3 target = new Vector3(0, 0, 0);
                        c.transform.LookAt(camera.transform, Vector3.up);

                    }
                }
            }
        }
        /*
        Vector3 cbPos = new Vector3(camera.transform.position.x, camera.transform.position.y - 1f, camera.transform.position.z);//camera.ViewportToWorldPoint(new Vector3(0.5f,0.5f,-5));
        GameObject cb = Instantiate<GameObject>(prefab, cbPos, Quaternion.identity, parent);
        //cb.transform.localScale = Vector3.one;
        Vector3 target2 = new Vector3(0, cbPos.y, 0);
        cb.transform.LookAt(target2);
        gameMaster.SetTargetPos(figure, camera.transform.position);
        */
    }
    public void Delete()
    {
        if (parent != null)
            DestroyImmediate(parent.gameObject);
    }
    void Update()
    {
        
    }
}
