using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = new Color(160,160,20);
    }
}
