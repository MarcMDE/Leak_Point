using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotationDuration;
    private bool staticState = false;
    bool rotateToTarget = false;
    float count;
    private Vector3 rotation;
    private Quaternion oldRotation;
    Quaternion sourceRotation;
    void Start()
    {
        oldRotation = transform.rotation;
        rotation = new Vector3(Random.Range( -20, 20 ), Random.Range( -20, 20 ), Random.Range( -20, 20 ));
        transform.Rotate(rotation);
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if( !staticState ){
            transform.Rotate(rotation*Time.deltaTime);
        }
        else if(rotateToTarget)
        {
            if (count < 1f)
            {
                count += Time.deltaTime/rotationDuration;
                transform.rotation = Quaternion.Lerp(sourceRotation, oldRotation, count);
            }
            else
            {
                rotateToTarget = false;
            }
        }
    } 

    public void RotateToTarget()
    {
        rotateToTarget = true;
        sourceRotation = transform.rotation;
        staticState = true;
    }
}
