using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    public GameObject player;
    public CubeMoving cubeMovingScript;

    IEnumerator returnPlayer(int i)
    {
        yield return new WaitForSeconds(0.5f);
        cubeMovingScript.StartMoving(i);
        cubeMovingScript.movementFreeze = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "edges")
        {
            if (other.GetComponent<Renderer>().material.color == transform.GetComponent<Renderer>().material.color)
            {
                Debug.Log("Color matching. Current color: " + other.GetComponent<Renderer>().material.color);
            }
            else
            {
                Debug.Log("Color NOT matching. Current color: " + other.GetComponent<Renderer>().material.color + "Need color: " + transform.GetComponent<Renderer>().material.color);
                // Searching a position to return the player to
                float deltaX = transform.position.x - cubeMovingScript.previousPos.x;
                float deltaZ = transform.position.z - cubeMovingScript.previousPos.z;
                Debug.Log(deltaX + " " + deltaZ);

                cubeMovingScript.movementFreeze = true;
                if (deltaZ < 0) // up
                {
                    Debug.Log("Return player up. DeltaZ = " + deltaZ + " < 0");
                    StartCoroutine(returnPlayer(0));
                }
                else if (deltaZ > 0) // down
                {
                    Debug.Log("Return player down. DeltaZ = " + deltaZ + " > 0");
                    StartCoroutine(returnPlayer(1));
                }
                else if (deltaX > 0) // left
                {
                    Debug.Log("Return player left. DeltaX = " + deltaX + " > 0");
                    StartCoroutine(returnPlayer(2));
                }
                else if (deltaX < 0) // right
                {
                    Debug.Log("Return player right. DeltaX = " + deltaX + " < 0");
                    StartCoroutine(returnPlayer(3));
                }
            }
        }
        else return;
    }
}
