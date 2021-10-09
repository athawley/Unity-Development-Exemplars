using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAllShadersForCamera : MonoBehaviour
{
    public Shader toonEffectShader;

    // Start is called before the first frame update
    
    void Start()
    {

        Camera myCamera = GetComponent<Camera>();

        myCamera.SetReplacementShader(toonEffectShader, "RenderType");
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
