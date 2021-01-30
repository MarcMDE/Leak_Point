using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] GameObject terraincube;
    [SerializeField] Transform grandParent;
    [SerializeField] float blockSize;
    [SerializeField] int sizeX;
    [SerializeField] int sizeZ;
    [SerializeField] float randomOffset;
    [SerializeField] float intensity;
    Transform parent;
    public void Generate()
    {
        parent = new GameObject("parent").transform;
        parent.transform.parent = grandParent;

        //cubes = new GameObject[];
        
        
        for (int px = 0; px < sizeX; px ++) {
            for (int py = 0; py< sizeZ; py ++) {
        
                var Perlin1 = Mathf.PerlinNoise((px/30f*intensity)*blockSize , (76f*intensity)*blockSize) + Random.Range(-randomOffset, randomOffset);
                var Perlin2 = Mathf.PerlinNoise((py/30f*intensity)*blockSize , (22f*intensity)*blockSize) + Random.Range(-randomOffset, randomOffset);
                Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0));
                var cube = Instantiate<GameObject>(terraincube, new Vector3(blockSize*(py-(sizeX/2)), Perlin1*40*Perlin2, blockSize*(px-(sizeX/2))), rot, parent);
                Vector3 scale = Vector3.one * blockSize;
                cube.transform.localScale = scale;
            }
        }

    }
    public void Delete()
    {
        if (parent != null)
            DestroyImmediate(parent.gameObject);
    }
    void Start()
    {   
         
    
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
