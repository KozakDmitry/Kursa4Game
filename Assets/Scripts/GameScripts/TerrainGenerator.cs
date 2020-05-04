using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public GameObject Cell;
    public Transform Zero;
    public float Heigth, Width;
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for (int x = 0; x < Width; x++)
        {
            var cell = Instantiate(Cell, Zero);
            cell.transform.localPosition = new Vector3(x, 0, 0);
        }
    }
}