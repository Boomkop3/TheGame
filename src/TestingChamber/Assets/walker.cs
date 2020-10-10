using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class walker : MonoBehaviour
{
    public static float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.A);
        bool back = Input.GetKey(KeyCode.S);
        bool forth = Input.GetKey(KeyCode.W);

        if (right) gameObject.move(ext.Direction.RIGHT, speed);
        if (left) gameObject.move(ext.Direction.LEFT, speed);
        if (back) gameObject.move(ext.Direction.BACK, speed);
        if (forth) gameObject.move(ext.Direction.FORTH, speed);
    }
}
