using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoving : MonoBehaviour
{
    private Vector3 forwardRotationPoint;
    private Vector3 backRotationPoint;
    private Vector3 leftRotationPoint;
    private Vector3 rightRotationPoint;

    private Bounds bounds;
    private bool rolling;

    public float speed;
    public float delay;

    void Start()
    {
        bounds = GetComponent<MeshRenderer>().bounds;

        forwardRotationPoint = new Vector3(0, -bounds.extents.y, bounds.extents.z);
        backRotationPoint = new Vector3(0, -bounds.extents.y, -bounds.extents.z);
        leftRotationPoint = new Vector3(-bounds.extents.x, -bounds.extents.y, 0);
        rightRotationPoint = new Vector3(bounds.extents.x, -bounds.extents.y, 0);
    }

    void Update()
    {

        if (rolling)
            return;

        if (Input.GetKey("up"))
        {
            StartCoroutine(move(forwardRotationPoint));
        }
        else if (Input.GetKey("down"))
        {
            StartCoroutine(move(backRotationPoint));
        }
        else if (Input.GetKey("left"))
        {
            StartCoroutine(move(leftRotationPoint));
        }
        else if (Input.GetKey("right"))
        {
            StartCoroutine(move(rightRotationPoint));
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
        rolling = false;
    }

}
