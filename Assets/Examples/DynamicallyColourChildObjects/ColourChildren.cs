using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChildren : MonoBehaviour
{
    [SerializeField] Material m;
    // Start is called before the first frame update
    void Start()
    {
        if(m == null) {
            
            m = new Material(Resources.Load<Material>("Materials/DefaultMaterial"));
            m.color = new Color32((byte)Random.Range(0,255), (byte)Random.Range(0,255), (byte)Random.Range(0,255), 0);
        }
        foreach(Renderer r in GetComponentsInChildren<Renderer>()) {
            r.material = m;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
