using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "edges")
        {
            Debug.Log("Win!");
            // Прописать окончание игрыы
        }
        else return;
    }
}
