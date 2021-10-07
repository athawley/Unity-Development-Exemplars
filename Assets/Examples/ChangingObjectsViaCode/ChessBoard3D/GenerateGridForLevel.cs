using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGridForLevel : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] int levels;
    // Start is called before the first frame update

    [Range(0,100)]
    [SerializeField]
    int gridScale = 5;

    public bool isEven = true;

    GameObject[,,] grid;
    void Start()
    {
        grid = new GameObject[levels, rows, columns];
        
        for(int l = 0; l < levels; l++) {
            for(int r = 0; r < rows; r++) {
                for(int c = 0; c < columns; c++) {
                    if((l % 2 == 0 && r % 2 == 0 && c % 2 == 0) || (l % 2 == 0 && r % 2 == 1 && c % 2 == 1) || (l % 2 == 1 && r % 2 == 0 && c % 2 == 1) || (l % 2 == 1 && r % 2 == 1 && c % 2 == 0)) {
                        //grid[l,r,c] = GameObject.CreatePrimitive(PrimitiveType.Plane);
                        grid[l,r,c] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        grid[l,r,c].transform.localScale = new Vector3(gridScale,0.1f,gridScale);
                        grid[l,r,c].GetComponent<Renderer>().material.color = Color.red;
                        grid[l,r,c].transform.SetPositionAndRotation(new Vector3(gridScale * r,gridScale * l,gridScale * c), Quaternion.identity);
                        grid[l,r,c].transform.SetParent(this.transform);
                    }
                }
            }
        }
    }

}
