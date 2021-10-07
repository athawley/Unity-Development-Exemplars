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
        int solidIndex;
        if(isEven) {
            solidIndex = 0;
        } else {
            solidIndex = 1;
        }
        //this.transform.
        //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        for(int l = 0; l < levels; l++) {
            for(int r = 0; r < rows; r++) {
                for(int c = 0; c < columns; c++) {
                    if((r % 2 == 0 && c % 2 == 0) || (r % 2 == 1 && c % 2 == 1)) {
                        //grid[l,r,c] = GameObject.CreatePrimitive(PrimitiveType.Plane);
                        grid[l,r,c] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        grid[l,r,c].transform.localScale = new Vector3(gridScale,0f,gridScale);
                        grid[l,r,c].GetComponent<Renderer>().material.color = Color.black;
                        grid[l,r,c].transform.SetPositionAndRotation(new Vector3(gridScale * r,gridScale * l,gridScale * c), Quaternion.identity);
                        grid[l,r,c].transform.SetParent(this.transform);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
