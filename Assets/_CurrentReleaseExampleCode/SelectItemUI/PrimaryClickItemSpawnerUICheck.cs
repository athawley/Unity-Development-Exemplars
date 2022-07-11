using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. Import InputSystem
using UnityEngine.InputSystem;

public class PrimaryClickItemSpawnerUICheck : MonoBehaviour
{
    // 2. Add Input actions (requires Generate C# script checked)
    private MouseControlsPointAndClick _controls;
    // 3. list of prefabs to be able to spawn (placeholder for later task)
    public GameObject[] prefabs = new GameObject[4]; //Prefabs to spawn
    // 4. List to store spawned gameobjects to be able to manage them.
    public List<GameObject> spawnedItems = new List<GameObject>();

    // 5. Currently selected prefab from list. Only default in this example
    public int selectedPrefab = 0;
    
    public float maxRayDistance = 300;

    public LayerMask ignoreLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        // 7. Create new input actions using the C# script
        _controls = new MouseControlsPointAndClick();
        // 8. Enable / turn on the MouseRTS action map
        _controls.MouseRTS.Enable();
        // 9. When the PrimaryAction binding is performed call the PrimaryPerformed function
        _controls.MouseRTS.PrimaryAction.performed += PrimaryPerformed;
        /* 10. 
        When the PrimaryAction binding is released call the PrimaryCancelled function
        Not used in this example
        */
        _controls.MouseRTS.PrimaryAction.performed += PrimaryCancelled;
        // 11. Right mouse button pressed
        _controls.MouseRTS.SecondaryAction.performed += SecondaryPerformed;
        // 12. Right mouse button cancelled / released (not used)
        _controls.MouseRTS.SecondaryAction.canceled += SecondaryCancelled;
    }

    /* 13. 
    Primary button pressed. When left mouse pressed do this.
    Get the context of the button (what happened)
    This will cast a ray from the mouse position and see what it hits.
    */
    void PrimaryPerformed(InputAction.CallbackContext context) {
        // 15. Store the raycast hit result
        RaycastHit hit;
        // 16. Create a ray from the current mouse position through the screen towards the scene
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        /* 17. 
        Cast the ray using the physics engine and see what it hits.
        Store what it (output) hits in the hit variable created earlier
        */
        if (Physics.Raycast(ray, out hit))
        {
            // 18. We are here because the raycast hit something Check if hit UI
            if(hit.collider.gameObject.layer != ignoreLayerMask.value) {

                /* 19.
                This is a messy check for the if statement.
                There are two main checks carried out.
                First we need to see if the parent of the hit object does not exist (e.g. hit null)
                Or check that the object it hit was not one of the objects tagged with
                player that we have spawned (otherwise we can spawn objects on top of each other)
                */
                if(hit.collider.transform.parent == null || hit.collider.transform.parent.CompareTag("Player") == false) {
                    /* 20. 
                    If we pass this instantiate (create) the object at the point the we hit
                    the terrain (or other object)
                    We use Quarternion.identiy to spawn it at the world space.
                    */
                    GameObject go = Instantiate(prefabs[selectedPrefab], hit.point, Quaternion.identity);
                    // 21. Update the name of the prefab instance
                    go.name += " _instantiated";
                    // 22. Add it to the spawned items list.
                    spawnedItems.Add(go);
                }
            }
        } 
    }

    // 14. Primary button released not used in this example.
    void PrimaryCancelled(InputAction.CallbackContext context) {
                
    }

    /* 23.
    Now we want to despawn the item when we right click on it
    */
    void SecondaryPerformed(InputAction.CallbackContext context) {
        // 23. We run the same kind of checks as before but this runs when we right click
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
        {
            /* 24.
            Check if we hit the parent gameobject with the tag Player.
            */
            if(hit.collider.transform.parent != null && hit.collider.transform.parent.CompareTag("Player")) {
                // 25. If so remove the gameobject from the spawnedItems list
                spawnedItems.Remove(hit.transform.parent.gameObject);
                // 26. Then destroy the object to free up memory and remove it from the scene.
                Destroy(hit.transform.parent.gameObject);
            }
        }   
    }

    // 27. Not used in this example
    void SecondaryCancelled(InputAction.CallbackContext context) {
                
    }
}