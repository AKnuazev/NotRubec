using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;

    private float minSwipeDistance = 75f;
    private float minDelta = 20f;

    //private bool detectSwipeOnlyAfterRelease = true;

    public static event Action<GlobalVariables.SwipeData> onSwipe = delegate { };

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPos = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUpPos = touch.position;
                DetectSwipe();
            }
        }


        //For manual test without phone(using mouse swipes)

        //if (Input.GetMouseButtonDown(0))
        //{
        //    fingerDownPos = Input.mousePosition;
        //    //fingerDownPos = Input.mousePosition;
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    fingerUpPos = Input.mousePosition;
        //    DetectSwipe();
        //}
    }

    void DetectSwipe()
    {
        if (SwipeDistanceCheck())
        {
            float angle = GetAngle();

            if (angle > minDelta && angle < 90f - minDelta)
                SendSwipe(GlobalVariables.Direction.Up);
            else if (angle > 90f + minDelta && angle < 180f - minDelta)
                SendSwipe(GlobalVariables.Direction.Left);
            else if (angle > 180f + minDelta && angle < 270f - minDelta)
                SendSwipe(GlobalVariables.Direction.Down);
            else if (angle > 270f + minDelta && angle < 360f - minDelta)
                SendSwipe(GlobalVariables.Direction.Right);
            else Debug.Log("angle error");
        }
    }

    private bool SwipeDistanceCheck()
    {
        return (VerticalSwipeDistance() > minSwipeDistance || HorizonalSwipeDistance() > minSwipeDistance);
    }

    private float VerticalSwipeDistance()
    {
        return Mathf.Abs(fingerUpPos.y - fingerDownPos.y);
    }

    private float HorizonalSwipeDistance()
    {
        return Mathf.Abs(fingerUpPos.x - fingerDownPos.x);
    }

    private void SendSwipe(GlobalVariables.Direction dir)
    {
        GlobalVariables.SwipeData swipeData = new GlobalVariables.SwipeData()
        {
            direction = dir,
            startPos = fingerDownPos,
            endPos = fingerUpPos
        };
        Debug.Log("Swipe direction: " + dir + " Swipe distanceX: " + (Mathf.Abs(fingerUpPos.x - fingerDownPos.x)) + " Swipe distanceY: " + (Mathf.Abs(fingerUpPos.y - fingerDownPos.y)));
        onSwipe(swipeData);
    }

    private float GetAngle()
    {
        float angle = Mathf.Atan2((fingerUpPos.y - fingerDownPos.y), (fingerUpPos.x - fingerDownPos.x)) * Mathf.Rad2Deg;
        if (angle >= 0)
            return angle;
        else
            return 360 + angle;
    }
}
