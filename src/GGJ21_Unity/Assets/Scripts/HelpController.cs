using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject reticle, help;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            help.SetActive(!help.activeInHierarchy);
            reticle.SetActive(!reticle.activeInHierarchy);
        }
    }
}
