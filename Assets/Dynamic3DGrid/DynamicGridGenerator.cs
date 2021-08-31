using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicGridGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int gridRows = 7, gridColumns = 5;
    private GameObject[,] grid;

    public Slider rowSlider, colSlider;
    void Start()
    {
        grid = new GameObject[gridRows,gridColumns];
        rowSlider.value = gridRows;
        colSlider.value = gridColumns;
        //GenerateGrid(rowSlider.value, colSlider.value);
    }

    void Awake() {
        colSlider.onValueChanged.AddListener(ListenerMethod);
        rowSlider.onValueChanged.AddListener(ListenerMethod);
    }

    public void ListenerMethod(float value)
    {
        for(int r = 0; r < grid.GetLength(0); r++) {
            for(int c = 0; c < grid.GetLength(1); c++) {
                Destroy(grid[r,c]);
            }
        }
        GenerateGrid(rowSlider.value, colSlider.value);
    }

    void GenerateGrid(float rows, float cols) {
        GenerateGrid((int)rows, (int)cols);
    }

    void GenerateGrid(int rows, int cols) {
        grid = new GameObject[rows,cols];
        



        for(int r = 0; r < grid.GetLength(0); r++) {
            for(int c = 0; c < grid.GetLength(1); c++) {
                //GameObject origin = new GameObject();
                //origin.transform.position = new Vector3(r,0,c);
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                

                float height = Random.Range(1,5);

                cube.GetComponent<Renderer>().material.color = Random.ColorHSV();

                cube.transform.localScale = new Vector3(cube.transform.localScale.x, height, cube.transform.localScale.z);
                cube.transform.position = new Vector3(r,height/2,c);
                cube.transform.SetParent(transform);

                grid[r,c] = cube;
            }
        }
    }
}
