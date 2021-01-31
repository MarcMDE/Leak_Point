using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool boolmap = false;
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject map;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            pointer.SetActive(boolmap);
            boolmap = !boolmap;
            map.SetActive(boolmap);
        }
    }
}
