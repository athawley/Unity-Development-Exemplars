using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractableHandler : MonoBehaviour
{
    Collider interactableObjectInRange;

    public GameObject interactableItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        interactableObjectInRange = col;
    }

    void OnTriggerExit(Collider col) {
        if(interactableObjectInRange.Equals(col)) {
            interactableObjectInRange = null;
        }
    }

    void OnFire() {
        if(interactableObjectInRange == null) {
            return;
        }
        InteractableItem script;
        if(interactableObjectInRange.gameObject.TryGetComponent<InteractableItem>(out script)) {
            if(script.inRange) {
                Debug.Log("Player detected in range and fire pressed");
                float xPos = Random.RandomRange(-10,10);
                float zPos = Random.RandomRange(-10,10);
                Instantiate(interactableItemPrefab, new Vector3(xPos, 0.5f, zPos), Quaternion.identity);
                Destroy(interactableObjectInRange.gameObject);
            }
        }
    }
}
