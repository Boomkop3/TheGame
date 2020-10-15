using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Assets;
using Assets.Code.Library;

namespace Assets.Code.Spritesheets
{
    public class Simple_spritesheet_animator : MonoBehaviour
    {
        [Header("Settings")]
        public int num_sprites_width = 1;
        public int num_sprites_height = 1;
        [Space(5)]
        public AnimationSegment[] animations;

        [Header("Info")]
        [ShowOnly] public string current_animation_name = "None";
        public float frametime
        {
            get
            {
                if (currentAnimation != null)
                {
                    return 1.0f / currentAnimation.framerate;
                }
                return 0.05f;
            }
        }
        [ShowOnly] public int currentFrame;
        private AnimationSegment currentAnimation;

        [Header("Developer")]
        public bool debug = false;

        private Material material;
        private Vector2 scale;
        private float timeDelta = 0;

        private int spriteX, spriteY = 0;
        private Vector2 offset;
        private float spriteFractionWidth, spriteFractionHeight;

        void Start()
        {
            // get material
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            material = meshRenderer.material;
            init();
            // Set first offset
            offset = getOffset(spriteX, spriteY);
            // fuck off
            debug = false;
        }

        void init()
        {
            // calculate scale
            spriteFractionWidth = 1.0f / num_sprites_width;
            spriteFractionHeight = 1.0f / num_sprites_height;
            scale = new Vector2(
                spriteFractionWidth,
                spriteFractionHeight
            );
            // load first animation
            if (currentAnimation == null && animations.Length > 0)
            {
                loadAnimation(animations[0]);
            }
        }

        public AnimationSegment getAnimationByName(string name)
        {
            foreach (var animation in animations)
            {
                if (animation.name == name)
                {
                    return animation;
                }
            }
            return null;
        }

        public void loadAnimation(AnimationSegment animation)
        {
            if (currentAnimation == animation) return;
            currentAnimation = animation;
            current_animation_name = animation.name;
            spriteX = animation.startX;
        }

        // Update is called once per frame
        void Update()
        {
            if (debug)
            {
                init();
            }
            material.mainTextureScale = scale;
            material.mainTextureOffset = offset;
            timeDelta += Time.deltaTime;
            if (timeDelta >= frametime)
            {
                nextFrame();
                timeDelta -= frametime;
            }
        }

        private void nextFrame()
        {
            int initialX = 0;
            if (currentAnimation != null) initialX = currentAnimation.startX;
            currentFrame = spriteY * num_sprites_width + spriteX - initialX;
            spriteX += 1;
            if (spriteX == num_sprites_width)
            {
                spriteX = initialX;
                spriteY += 1;
                if (spriteY == num_sprites_height)
                {
                    spriteY = 0;
                }
            }
            int globalX = spriteX;
            int globalY = spriteY;
            if (currentAnimation != null)
            {
                if (currentFrame >= currentAnimation.num_of_frames)
                {
                    spriteX = initialX;
                    spriteY = 0;
                }
                globalY += currentAnimation.startY;
            }
            offset = getOffset(globalX, globalY + 1);
        }

        private Vector2 getOffset(int x, int y)
        {
            float uvX = x * spriteFractionWidth;
            float uvY = (num_sprites_height - y) * spriteFractionHeight;
            if (debug)
            {
                Debug.Log("AnimX: " + x + " AnimY: " + y);
                Debug.Log("x: " + uvX);
                Debug.Log("y: " + uvY);
            }
            return new Vector2(
                uvX,
                uvY
            );
        }
    }
}