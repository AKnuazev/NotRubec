using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "edges")
        {
            other.GetComponent<Renderer>().material.color = transform.GetComponent<Renderer>().material.color;
        }
        else return;
            
        Debug.Log("Current color: " + other.GetComponent<Renderer>().material.color);
    }
}
