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

        if (right) gameObject.move(ext.Direction.RIGHT);
        if (left) gameObject.move(ext.Direction.LEFT);
        if (back) gameObject.move(ext.Direction.BACK);
        if (forth) gameObject.move(ext.Direction.FORTH);
    }
}

public static class ext
{
    public enum Direction
    {
        RIGHT, LEFT, UP, DOWN, BACK, FORTH
    }
    public static void move (this GameObject obj, Direction direction)
    {
        switch (direction)
        {
            case Direction.BACK:
                {
                    obj.transform.position = new Vector3(
                        obj.transform.position.x,
                        obj.transform.position.y,
                        obj.transform.position.z - walker.speed
                    );
                    break;
                }
            case Direction.FORTH:
                {
                    obj.transform.position = new Vector3(
                        obj.transform.position.x,
                        obj.transform.position.y,
                        obj.transform.position.z + walker.speed
                    );
                    break;
                }
            case Direction.LEFT: 
                {
                    obj.transform.position = new Vector3(
                        obj.transform.position.x - walker.speed,
                        obj.transform.position.y,
                        obj.transform.position.z
                    );
                    break;
                }
            case Direction.RIGHT:
                {
                    obj.transform.position = new Vector3(
                        obj.transform.position.x + walker.speed,
                        obj.transform.position.y,
                        obj.transform.position.z
                    );
                    break;
                }
            case Direction.UP:
                {
                    obj.transform.position = new Vector3(
                        obj.transform.position.x,
                        obj.transform.position.y + walker.speed,
                        obj.transform.position.z
                    );
                    break;
                }
            case Direction.DOWN:
                {
                    obj.transform.position = new Vector3(
                        obj.transform.position.x,
                        obj.transform.position.y - walker.speed,
                        obj.transform.position.z
                    );
                    break;
                }
        }
    }
}
