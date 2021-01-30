using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private bool moving = false;
    [SerializeField] float thrust = 1.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space") && rb.velocity == Vector3.zero)
        {
            rb.AddForce(Camera.main.transform.forward * thrust);
            //moving = true;
        }
        
        //if (rb.velocity == 0)
    }

    private void OnCollisionStay(Collision collision){
        if (Input.GetKey("space")){
            rb.velocity = Vector3.zero;
            //moving = false;
        }

    }
}
