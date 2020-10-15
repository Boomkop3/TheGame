using Assets.Code.Player;
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
        Debug.Log(
            "press "
            + Controls.WalkingDirection.keys.down.keyName
            + " to do get of the old grumps lawn"
        );
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
