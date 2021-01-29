using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private Vector3 speed;
    private bool moving = false;
    public float thrust = 1.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space") && !moving){
            rb.AddForce(transform.forward * thrust* 100* Time.deltaTime);
            moving = true;
            speed = transform.forward;
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (Input.GetKey("space")){

            rb.velocity = Vector3.zero;
            moving = false;
        }

    }
}
