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
    // [Space(5)]
    // public AnimationSegment[] animations;

    [Header("Info")]
    // [ShowOnly] public string current_animation = "None";
    [ShowOnly] public float frametime;
    // private AnimationSegment currentAnimation;

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
        /*
        if (animations.Length > 0)
        {
            loadAnimation(animations[0]);
        }
        */
    }

    /*
    void loadAnimation(AnimationSegment animation)
    {
        currentAnimation = animation;
        current_animation = animation.name;
    }
    */

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
        offset = getOffset(spriteX, spriteY);
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
