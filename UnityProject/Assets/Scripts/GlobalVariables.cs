using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Stop
    }

    public struct SwipeData
    {
        public Vector2 startPos;
        public Vector2 endPos;
        public Direction direction;
    }
}
