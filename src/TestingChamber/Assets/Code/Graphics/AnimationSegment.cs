using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Assets;

[Serializable]
public class AnimationSegment
{
    public string name;
    public int startX;
    public int startY;
    public int num_of_frames;
    [Range(1, 60)]
    public int framerate;
    public AnimationSegment()
    {
        this.name = "MyAnimation";
        this.startY = 0;
        this.num_of_frames = 0;
        this.framerate = 20;
    }
    public AnimationSegment(string name, int startLine, int num_of_frames, int framerate)
    {
        this.name = name;
        this.startY = startLine;
        this.num_of_frames = num_of_frames;
        this.framerate = framerate;
    }
}
