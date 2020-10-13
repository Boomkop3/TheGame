using Assets.Code.Graphics;
using Assets.Code.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Direction = Assets.Code.Library.VectorMovement.Direction;

namespace Assets.Code.Player
{
    public class Walker : MonoBehaviour
    {
        public float speed = 0.0025f;
        Simple_spritesheet_animator animator;
        private AnimationSegment runningRightAnimation;
        private AnimationSegment runningLeftAnimation;
        private AnimationSegment standingAnimation;

        void Start()
        {
            animator = gameObject.transform.GetComponent<Simple_spritesheet_animator>();
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
            gameObject.GetComponent<Rigidbody>().move(Direction.RIGHT, Controls.WalkingDirection.x * speed);
            gameObject.GetComponent<Rigidbody>().move(Direction.FORTH, Controls.WalkingDirection.y * speed);
        }
    }
}