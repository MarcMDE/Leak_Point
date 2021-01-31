using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderController : MonoBehaviour
{
    // Start is called before the first frame update
    bool rotation = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (!rotation && collision.gameObject.tag == "Player")
        {
            rotation = true;
            var cubes = GameObject.FindGameObjectsWithTag("FigCube");
            foreach (var c in cubes)
            {
                c.GetComponent<CubeController>().RotateToTarget();
            }
        }   
    }*/
}
