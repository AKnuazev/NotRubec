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
    //private Vector3 forwardRotationPoint;
    //private Vector3 backRotationPoint;
    //private Vector3 leftRotationPoint;
    //private Vector3 rightRotationPoint;

    public float speed;
    public float delay;

    private Bounds bounds;

    [SerializeField]
    public Vector3 previousPos;

    private bool rolling;

    [SerializeField]
    public bool movementFreeze; // 1 - player cant move

    void Start()
    {
        bounds = GetComponent<MeshRenderer>().bounds;

        //forwardRotationPoint = new Vector3(0, -bounds.extents.y, bounds.extents.z);
        //backRotationPoint = new Vector3(0, -bounds.extents.y, -bounds.extents.z);
        //leftRotationPoint = new Vector3(-bounds.extents.x, -bounds.extents.y, 0);
        //rightRotationPoint = new Vector3(bounds.extents.x, -bounds.extents.y, 0);

        rotationPoints[0] = new Vector3(0, -bounds.extents.y, bounds.extents.z);
        rotationPoints[1] = new Vector3(0, -bounds.extents.y, -bounds.extents.z);
        rotationPoints[2] = new Vector3(-bounds.extents.x, -bounds.extents.y, 0);
        rotationPoints[3] = new Vector3(bounds.extents.x, -bounds.extents.y, 0);

        previousPos = transform.position;
        rolling = false;
        movementFreeze = false;
    }

    public void startMoving(int direction)
    {
        previousPos = transform.position;
        StartCoroutine(move(rotationPoints[direction]));
    }

    void Update()
    {
        if (rolling)
            return;

        if (Input.GetKey("up") && movementFreeze == false)
        {
            //StartCoroutine(move(forwardRotationPoint));
            //startMoving(forwardRotationPoint);
            startMoving(0);
        }
        else if (Input.GetKey("down") && movementFreeze == false)
        {
            //StartCoroutine(move(backRotationPoint));
            //startMoving(backRotationPoint);
            startMoving(1);
        }
        else if (Input.GetKey("left") && movementFreeze == false)
        {
            //StartCoroutine(move(leftRotationPoint));
            //startMoving(leftRotationPoint);
            startMoving(2);
        }
        else if (Input.GetKey("right") && movementFreeze == false)
        {
            //StartCoroutine(move(rightRotationPoint));
            //startMoving(rightRotationPoint);
            startMoving(3);
        }
    }

    IEnumerator move(Vector3 rotationPoint)
    {
        Vector3 point = transform.position + rotationPoint;
        Vector3 axis = Vector3.Cross(Vector3.up, rotationPoint).normalized;
        float angle = 90;
        float a = 0;

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
        transform.position = new Vector3((float)Math.Round((double)transform.position.x, 1),
                                    (float)Math.Round((double)transform.position.y, 1),
                                    (float)Math.Round((double)transform.position.z, 1));
        rolling = false;
    }

}
