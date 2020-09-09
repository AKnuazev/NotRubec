using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    public GameObject player;
    public float delta;
    public float speed;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Math.Abs(player.transform.position.x + startPos.x - transform.position.x) >= delta)
        //{
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + startPos.x, startPos.y, startPos.z), speed * Time.deltaTime);
        //}

        //if (Math.Abs(player.transform.position.z + 15f - transform.position.z) >= delta)
        //{
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(startPos.x, startPos.y, player.transform.position.z + startPos.z), speed * Time.deltaTime);
        //}

        transform.position = Vector3.Lerp(transform.position,
            new Vector3(player.transform.position.x + startPos.x,
                        startPos.y,
                        player.transform.position.z + startPos.z),
            speed * Time.deltaTime);
    }
}
