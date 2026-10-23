using System;
using UnityEngine;
public enum ImagePosition
{
    Left,
    Right
}

[Serializable]
public class Dialogue
{
    public string name;
    public Sprite image;
    public ImagePosition position;

    [TextArea(3,10)]
    public string[] sentences;
}
