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

    [SerializeField] GameObject[] pointerObj;

    //[SerializeField]
    bool isGrounded;
    bool grabed;
    bool loading;

    float impulseCounter;
    Vector3 velocity;
    Vector3 move;

    //Rigidbody rb;
    CharacterController controller;

    private float grabDisabled = 0;
    
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
        if(grabDisabled == 0){
             //rb.velocity = Vector3.zero;
            transform.parent = t;
            grabed = true;
            velocity = Vector3.zero;
            move = Vector3.zero;
            //rb.useGravity = false;
        }
       
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
        var timeSegment = 0.5f/3;//maxImpulseTime-0.5f/(pointerObj.Length - 2f);

        if(grabDisabled > 0){
            grabDisabled -= Time.deltaTime;
            
        }
        if(grabDisabled < 0){
            grabDisabled = 0;
        }
            
            
        if (isGrounded || grabed)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (impulseCounter < maxImpulseTime){
                    impulseCounter += Time.deltaTime;
                }else{
                    impulseCounter = maxImpulseTime;
                    pointerObj[0].SetActive(false);
                    pointerObj[1].SetActive(false);
                    pointerObj[2].SetActive(false);
                    pointerObj[3].SetActive(false);
                    pointerObj[4].SetActive(true);
                    Debug.Log("LOADING!");
                }
                    
                
                loading = true;
                //Debug.Log("LOADING!");


                if (impulseCounter >= 0.5f){
                    if (impulseCounter >= 0.5f + timeSegment){
                        if (impulseCounter >= 0.5f + 2*timeSegment){
                            if (impulseCounter < maxImpulseTime){

                            
                                pointerObj[0].SetActive(false);
                                pointerObj[1].SetActive(false);
                                pointerObj[2].SetActive(false);
                                pointerObj[3].SetActive(true);
                                pointerObj[4].SetActive(false);
                            }

                        }else{
                            pointerObj[0].SetActive(false);
                            pointerObj[1].SetActive(false);
                            pointerObj[2].SetActive(true);
                            pointerObj[3].SetActive(false);
                            pointerObj[4].SetActive(false);
                        }
                    }else{
                        pointerObj[0].SetActive(false);
                        pointerObj[1].SetActive(true);
                        pointerObj[2].SetActive(false);
                        pointerObj[3].SetActive(false);
                        pointerObj[4].SetActive(false);
                    }
                }
                
                    


                    
            }
            
            if(Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("KEY UP!");
                if (impulseCounter < 0.5f && isGrounded)
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
                    
                    pointerObj[0].SetActive(true);
                    pointerObj[1].SetActive(false);
                    pointerObj[2].SetActive(false);
                    pointerObj[3].SetActive(false);
                    pointerObj[4].SetActive(false);
                    grabDisabled = 0.25f;
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
