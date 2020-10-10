using extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Direction = extensions.ext.Direction;

public static class Controls
{
    private interface IControlAction
    {
        bool onPress { get; }
        bool onRelease { get; }
        bool whilePressed { get; }
        float analogValue { get; }
    }

    private class KeyboardControlAction : IControlAction
    {
        private KeyCode key;
        public KeyboardControlAction(KeyCode key)
        {
            this.key = key;
        }
        public bool onPress => Input.GetKeyDown(key);
        public bool onRelease => Input.GetKeyUp(key);
        public bool whilePressed => Input.GetKey(key);
        public float analogValue => whilePressed ? 1 : 0;
    }
    private static class KeyboardControls
    {
        public static IControlAction up;
        public static IControlAction down;
        public static IControlAction left;
        public static IControlAction right;
        static KeyboardControls()
        {
            up = new KeyboardControlAction(KeyCode.W);
            down = new KeyboardControlAction(KeyCode.S);
            left = new KeyboardControlAction(KeyCode.A);
            right = new KeyboardControlAction(KeyCode.D);
        }
    }
    public static class WalkingDirection
    {
        public static float x
        {
            get
            {
                float x = 0;
                if (KeyboardControls.right.whilePressed) x++;
                if (KeyboardControls.left.whilePressed) x--;
                return x;
            }
        }
        public static float y
        {
            get
            {
                float y = 0;
                if (KeyboardControls.up.whilePressed) y++;
                if (KeyboardControls.down.whilePressed) y--;
                return y;
            }
        }
        public static Direction direction
        {
            get
            {
                if (x < -0.5) return Direction.LEFT;
                if (x > 0.5) return Direction.RIGHT;
                if (y > 0.5) return Direction.UP;
                if (y < -0.5) return Direction.DOWN;
                return Direction.NONE;
            }
        }
    }
}

public class walker : MonoBehaviour
{
    public float speed = 0.0025f;
    simple_spritesheet_animator animator;
    private AnimationSegment runningRightAnimation;
    private AnimationSegment runningLeftAnimation;
    private AnimationSegment standingAnimation;

    void Start()
    {
        animator = gameObject.transform.GetComponentInChildren<simple_spritesheet_animator>();
        standingAnimation = animator.getAnimationByName("standing");
        runningRightAnimation = animator.getAnimationByName("running right");
        runningLeftAnimation = animator.getAnimationByName("running left");
    }

    void Update()
    {
       switch (Controls.WalkingDirection.direction)
        {
            case Direction.LEFT:
                animator.loadAnimation(runningLeftAnimation);
                break;
            case Direction.RIGHT:
                animator.loadAnimation(runningRightAnimation);
                break;
            case Direction.UP:
                animator.loadAnimation(standingAnimation);
                break;
            case Direction.DOWN:
                animator.loadAnimation(standingAnimation);
                break;
            default:
                animator.loadAnimation(standingAnimation);
                break;
        }
    }

    void FixedUpdate()
    {
        gameObject.move(Direction.RIGHT, Controls.WalkingDirection.x * speed);
        gameObject.move(Direction.FORTH, Controls.WalkingDirection.y * speed);
    }
}
