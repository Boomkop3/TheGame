using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smooth_follow : MonoBehaviour
{
    private Vector3 delta;
    public GameObject thing_to_follow;
    [Range(0,1)]
    public float speed;
    void Start()
    {
        delta = gameObject.transform.position - thing_to_follow.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 currentDelta = gameObject.transform.position - thing_to_follow.transform.position;
        Vector3 difference = delta - currentDelta;
        difference.Scale(new Vector3(speed, speed, speed));
        gameObject.transform.position = thing_to_follow.transform.position + (currentDelta + difference);
    }
}
