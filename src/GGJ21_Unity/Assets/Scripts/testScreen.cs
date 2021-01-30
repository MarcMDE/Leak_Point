using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScreen : MonoBehaviour
{
    [SerializeField] Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(camera.WorldToViewportPoint(transform.position));
    }
}
