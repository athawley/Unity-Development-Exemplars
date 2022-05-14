using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionDetection : MonoBehaviour
{

    Material m_Material;
    [SerializeField]
    Material m_seenMaterial, m_unseenMaterial;
    Renderer m_renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        m_renderer.material = m_unseenMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            Debug.Log("Player Seen");
            m_renderer.material = m_seenMaterial;
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.CompareTag("Player")) {
            Debug.Log("Player Ūnseen");
            m_renderer.material = m_unseenMaterial;
        }
    }
}
