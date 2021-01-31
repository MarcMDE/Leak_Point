using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera[] blockCameras;

    [SerializeField] Camera playerCamera;

    [SerializeField] GameObject[] canvasElements;
    [SerializeField] GameObject[] canvasGreenElements;
    [SerializeField] float SymbolCount;

    [SerializeField] float posThresh = 2f;
    [SerializeField] float angleThresh = 5f;
    private bool[] wins = {false,false,false,false};

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < SymbolCount; i++){
            if(!wins[i]){
                //if( i == 0 ) Debug.Log((blockCameras[i].transform.position - playerCamera.transform.position).magnitude);
                //if( i == 0 ) Debug.Log(Vector3.Angle(blockCameras[i].transform.forward, playerCamera.transform.forward));
                
                if((blockCameras[i].transform.position - playerCamera.transform.position ).magnitude < posThresh){
                    if( Vector3.Angle(blockCameras[i].transform.forward, playerCamera.transform.forward) < angleThresh){
                        wins[i] = true;
                        canvasElements[i].SetActive(false);
                        canvasGreenElements[i].SetActive(true);

                    }
                }
            }
        }
    }
}
