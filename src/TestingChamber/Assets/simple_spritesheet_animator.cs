#define debug
#undef debug

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class simple_spritesheet_animator : MonoBehaviour
{
    public int num_sprites_width = 1;
    public int num_sprites_height = 1;
    public int framerate = 15;

    private Material material;
    private Vector2 scale;
    private float timeDelta = 0;
    private float frametime;

    private int spriteX, spriteY = 0;
    private Vector2 offset;
    private float spriteFractionWidth, spriteFractionHeight;

    void Start()
    {
        // get material
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        // calculate scale
        spriteFractionWidth = 1.0f / num_sprites_width;
        spriteFractionHeight = 1.0f / num_sprites_height;
        scale = new Vector2(
            spriteFractionWidth,
            spriteFractionHeight
        );
        // calculate frametime
        frametime = 1.0f / framerate;
        // Set first offset
        offset = getOffset(spriteX, spriteY);
        /*
        offset = new Vector2(
            0.0f, 1.0f - spriteFractionHeight
        );
        */
    }

    // Update is called once per frame
    void Update()
    {
#if debug
        spriteFractionWidth = 1.0f / num_sprites_width;
            spriteFractionHeight = 1.0f / num_sprites_height;
            scale = new Vector2(
                spriteFractionWidth,
                spriteFractionHeight
            );
            frametime = 1.0f / framerate;
#endif
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
#if debug
        Debug.Log("AnimX: " + x + " AnimY: " + y);
        Debug.Log("x: " + uvX);
        Debug.Log("y: " + uvY);
#endif
        return new Vector2(
            uvX,
            uvY
        );
    }
}
