using System;

[Serializable]
public class AnimationSegment
{
    public string name;
    public int startX;
    public int startY;
    public int num_of_frames;
    public AnimationSegment()
    {
        this.name = "MyAnimation";
        this.startY = 0;
        this.num_of_frames = 0;
    }
    public AnimationSegment(string name, int startLine, int num_of_frames)
    {
        this.name = name;
        startY = startLine;
        this.num_of_frames = num_of_frames;
    }
}
