using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private bool moving = false;
    [SerializeField] float thrust = 1.0f;
    [SerializeField] float thrustSlowDownFactor = 0.1f;
    
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space") && !moving)
        {
            Vector3 thrustDirection = Camera.main.transform.forward;
            rb.AddForce( thrustDirection * thrust);
            moving = true;
        }
        
        //if (rb.velocity == 0)
    }

    private void FixedUpdate()
    {
        if (rb.velocity == Vector3.zero)
            moving = false;

        if (Mathf.Abs(rb.velocity.x) > thrustSlowDownFactor * Time.deltaTime || Mathf.Abs(rb.velocity.z) > thrustSlowDownFactor * Time.deltaTime)
        {
            Vector3 slowDirection = -rb.velocity.normalized;
            slowDirection.y = 0f;
            rb.AddForce(slowDirection * thrustSlowDownFactor * thrust * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }

    private void OnCollisionStay(Collision collision){
        if (Input.GetKey("space")){
            rb.velocity = Vector3.zero;
            //moving = false;
        }

    }
}
