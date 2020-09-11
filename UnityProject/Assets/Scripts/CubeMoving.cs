using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoving : MonoBehaviour
{
    private Vector3[] rotationPoints = new Vector3[4]; // 0 - forward
                                                       // 1 - back
                                                       // 2 - left
                                                       // 3 - right

    public float speed;
    public float delay;

    private Bounds bounds;
    private float edgeSize = 0.15f;

    [SerializeField]
    public Vector3 previousPos;

    private bool rolling;

    [SerializeField]
    public bool movementFreeze; // 1 - player cant move

    private GlobalVariables.SwipeData swipedata;
    void Start()
    {
        bounds = GetComponent<MeshRenderer>().bounds;

        rotationPoints[0] = new Vector3(0, -bounds.extents.y - edgeSize, bounds.extents.z + edgeSize);
        Debug.Log("0 " + rotationPoints[0]);
        rotationPoints[1] = new Vector3(0, -bounds.extents.y - edgeSize, -bounds.extents.z - edgeSize);
        Debug.Log("0 " + rotationPoints[1]);
        rotationPoints[2] = new Vector3(-bounds.extents.x - edgeSize, -bounds.extents.y - edgeSize, 0);
        Debug.Log("0 " + rotationPoints[2]);
        rotationPoints[3] = new Vector3(bounds.extents.x + edgeSize, -bounds.extents.y - edgeSize, 0);
        Debug.Log("0 " + rotationPoints[3]);

        previousPos = transform.position;
        rolling = false;
        movementFreeze = false;

        swipedata.direction = GlobalVariables.Direction.Stop;
        SwipeDetector.onSwipe += GetSwipeDirection_onSwipe;
        Debug.Log(swipedata.direction);
    }
    void Update()
    {
        if (rolling)
            return;

        if ((Input.GetKey("up") || swipedata.direction == GlobalVariables.Direction.Up) && movementFreeze == false)
        {
            StartMoving(0);
        }
        else if ((Input.GetKey("down") || swipedata.direction == GlobalVariables.Direction.Down) && movementFreeze == false)
        {
            StartMoving(1);
        }
        else if ((Input.GetKey("left") || swipedata.direction == GlobalVariables.Direction.Left) && movementFreeze == false)
        {
            StartMoving(2);
        }
        else if ((Input.GetKey("right") || swipedata.direction == GlobalVariables.Direction.Right) && movementFreeze == false)
        {
            StartMoving(3);
        }
    }

    IEnumerator move(Vector3 rotationPoint)
    {
        Vector3 point = transform.position + rotationPoint;
        Vector3 axis = Vector3.Cross(Vector3.up, rotationPoint).normalized;
        float angle = 90;
        float a = 0;

        swipedata.direction = GlobalVariables.Direction.Stop;
        rolling = true;

        while (angle > 0)
        {
            a = Time.deltaTime * speed;
            transform.RotateAround(point, axis, a);
            angle -= a;
            yield return null;
        }
        transform.RotateAround(point, axis, angle);

        yield return new WaitForSeconds(delay);

        // round up player position
        transform.position = new Vector3((float)Math.Round((double)transform.position.x, 1), transform.position.y,
                                    (float)Math.Round((double)transform.position.z, 1));
        rolling = false;
    }

    public void StartMoving(int direction)
    {
        previousPos = transform.position;
        StartCoroutine(move(rotationPoints[direction]));
    }

    private void GetSwipeDirection_onSwipe(GlobalVariables.SwipeData data)
    {
        swipedata.direction = data.direction;
    }
}
