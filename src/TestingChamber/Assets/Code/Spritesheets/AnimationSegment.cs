using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Assets;

namespace Assets.Code.Spritesheets
{
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
            name = "MyAnimation";
            startY = 0;
            num_of_frames = 0;
            framerate = 20;
        }
        public AnimationSegment(string name, int startLine, int num_of_frames, int framerate)
        {
            this.name = name;
            startY = startLine;
            this.num_of_frames = num_of_frames;
            this.framerate = framerate;
        }
    }
}