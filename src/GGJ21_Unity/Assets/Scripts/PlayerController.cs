using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool moving = false;
    [SerializeField] float jumpThrust;
    [SerializeField] float impulseThrust;
    [SerializeField] float walkingSpeed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float impulseGroth;
    [SerializeField] float maxImpulseTime;
    bool isGrounded;
    bool grabed;
    bool loading;

    float impulseCounter;
    Vector3 velocity;
    Vector3 move;

    //Rigidbody rb;
    CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        grabed = false;
        isGrounded = false;
        loading = false;
        impulseCounter = 0f;
        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

        //float correctHeight = controller.center.y + controller.skinWidth;
        //controller.center = new Vector3(0, correctHeight, 0);
        // set the controller center vector:
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            DropCube();
        }

        isGrounded = Physics.CheckSphere(transform.position, 0.13f, groundLayer, QueryTriggerInteraction.Ignore);
        Move();
    }

    private void FixedUpdate()
    {
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (Input.GetMouseButton(0))
        {
            GrabCube(hit.transform);
        }
    }

    private void GrabCube(Transform t)
    {
        //rb.velocity = Vector3.zero;
        transform.parent = t;
        grabed = true;
        velocity = Vector3.zero;
        move = Vector3.zero;
        //rb.useGravity = false;
    }

    private void DropCube()
    {
        transform.parent = null;
        grabed = false;
        //rb.useGravity = true;
    }

    private void Walk()
    {
        if (!grabed)
        {
            Vector3 walkForward = Input.GetAxis("Vertical") * new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
            Vector3 walkSide = Input.GetAxis("Horizontal") * new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;
            Vector3 walkDirection = (walkForward + walkSide);
            

            move = walkDirection * walkingSpeed;
            controller.Move(move * Time.deltaTime);
            
        }
    }

    private void Gravity()
    { 
        if (!grabed)
        {
            velocity += Physics.gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (isGrounded || grabed)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (impulseCounter < maxImpulseTime)
                    impulseCounter += Time.deltaTime;
                else
                    impulseCounter = maxImpulseTime;
                
                loading = true;
                //Debug.Log("LOADING!");
            }
            
            if(Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("KEY UP!");
                if (impulseCounter < 1f && isGrounded)
                {
                    velocity = Vector3.up * jumpThrust + move;

                    loading = false;
                    impulseCounter = 0f;

                    Debug.Log("JUMP!");
                    grabed = false;
                }
                else if (impulseCounter >= 0.5f)
                {
                    velocity = Camera.main.transform.forward * impulseCounter * impulseThrust;
                    Debug.Log("IMPULSE!");
                    grabed = false;
                }
            }
            
        }
        else
        {
            loading = false;
        }

        
    }

    private void Move()
    {
        Walk();

        if (isGrounded)
        {
            velocity = Physics.gravity;

            if (!loading)
            {
                impulseCounter = 0f;
            }
        }

        Jump();
        Debug.Log(isGrounded);
        Gravity();
        controller.Move(velocity * Time.deltaTime);
    }
}
