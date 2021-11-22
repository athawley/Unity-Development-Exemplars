using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_2_4_EaterOfWorlds_Answer : MonoBehaviour
{
    [SerializeField] float lifeTime;

    // Extension
    [SerializeField] float colourTime;
    bool colourChanged = false;
    


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Only for extension
    void Update()
    {
        if(gameObject.name == "Sun") {
            
            colourTime = colourTime - Time.deltaTime;
            if(colourChanged == false && colourTime <= 0 ) {
                Debug.Log("Here");
                // Death, change colour
                Renderer _rend;
                if(gameObject.TryGetComponent<Renderer>(out _rend)) {
                    _rend.material.color = Color.magenta;
                }
                colourChanged = true;
            }
        }
    }

}
