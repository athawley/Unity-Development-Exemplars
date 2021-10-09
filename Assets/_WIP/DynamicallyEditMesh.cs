using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicallyEditMesh : MonoBehaviour
{
     Mesh mesh;
    Vector3[] vertices;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        for (var i = 0; i < vertices.Length; i++)
        {
            Debug.Log(vertices[i]);
            vertices[i] = vertices[i] * Random.RandomRange(0.01f,1f);
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }

    void Update()
    {
     /*
        for (var i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices[i].x * i + 1, vertices[i].y * i + 1, vertices[i].z * i + 1);
        }
*/
        // assign the local vertices array into the vertices array of the Mesh.
  //      mesh.vertices = vertices;
    //    mesh.RecalculateBounds();
    }
}
