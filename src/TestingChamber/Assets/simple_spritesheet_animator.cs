using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Assets;

public class simple_spritesheet_animator : MonoBehaviour
{
    [Header("Settings")]
    public int num_sprites_width = 1;
    public int num_sprites_height = 1;
    [Range(1, 60)]
    public int framerate = 15;
    [Space(5)]
    public AnimationSegment[] animations;

    [Header("Info")]
    [ShowOnly] public string current_animation_name = "None";
    [ShowOnly] public float frametime;
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
        // calculate frametime
        frametime = 1.0f / framerate;
        // load first animation
        if (animations.Length > 0)
        {
            loadAnimation(animations[0]);
        }
    }

    void loadAnimation(AnimationSegment animation)
    {
        currentAnimation = animation;
        current_animation_name = animation.name;
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

    void nextFrame()
    {
        int initialX = 0;
        if (currentAnimation != null) initialX = currentAnimation.startX;
        currentFrame = (spriteY * num_sprites_width) + spriteX;
        spriteX += 1;
        if (spriteX == num_sprites_width)
        {
            spriteX = 0;
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
                spriteX = 0;
                spriteY = 0;
            }
            globalY += currentAnimation.startY;
        }
        offset = getOffset(globalX, globalY + 1);
    }

    Vector2 getOffset(int x, int y)
    {
        float uvX = x * spriteFractionWidth;
        float uvY = ((num_sprites_height - y) * spriteFractionHeight);
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
