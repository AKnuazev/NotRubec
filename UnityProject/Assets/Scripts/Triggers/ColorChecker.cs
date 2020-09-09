using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    public GameObject player;
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
            }
        }
        else return;
    }
}
