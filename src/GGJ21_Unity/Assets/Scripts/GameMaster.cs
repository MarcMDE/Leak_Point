using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Figure {H=0, X}

public class GameMaster : MonoBehaviour
{

    Vector3 [] targetPositions;

    void Start()
    {
        targetPositions = new Vector3[2];
    }

    public void SetTargetPos(Figure f, Vector3 t)
    {
        targetPositions[(int)f] = t;
    }
    
    public Vector3 GetTargetPos(Figure f)
    {
        return targetPositions[(int)f];
    }
}
