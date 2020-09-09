using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawnScript : MonoBehaviour
{
    public GameObject[] objects;
    // public List<List<int>> ColumnCoords = new List<List<int>>() { new List<int>() { 10, 10, 10 }, new List<int>() { 20, 20, 20 }, new List<int>() { 30, 30, 30 } };

    public List<Vector3> ColumnCoords = new List<Vector3>() { new Vector3(0, -5, 0), new Vector3(1, -5, 0), new Vector3(2, -5, 0), new Vector3(3, -5, 0), new Vector3(0, -5, 1),    new Vector3(1, -5, 1), new Vector3(2, -5, 1), new Vector3(3, -5, 1), new Vector3(0, -5, 2), new Vector3(1, -5, 2)};
    // Start is called before the first frame update
    void Start()
    {
        foreach (Vector3 vect in ColumnCoords)
        {
            Instantiate(objects[0], vect, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
