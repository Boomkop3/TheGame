using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOffMyLawn : MonoBehaviour
{
    void Start()
    {
           
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GET OFF MY LAWN");
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
