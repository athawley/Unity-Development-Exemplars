using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PrimaryClickItemSpawner : MonoBehaviour
{
    private MouseControlsPointAndClick _controls;
    public GameObject[] prefabs = new GameObject[4]; //Prefabs to spawn
    public List<GameObject> spawnedItems = new List<GameObject>();

    [SerializeField]
    CinemachineVirtualCamera _virtualCamera;
    int selectedPrefab = 0;
    int rayDistance = 300;

    bool primaryPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        _controls = new MouseControlsPointAndClick();
        _controls.MouseRTS.Enable();
        _controls.MouseRTS.PrimaryAction.performed += PrimaryPerformed;
        _controls.MouseRTS.PrimaryAction.performed += PrimaryCancelled;
        _controls.MouseRTS.SecondaryAction.performed += SecondaryPerformed;
        _controls.MouseRTS.SecondaryAction.performed += SecondaryCancelled;
    }

    // Primary button pressed
    void PrimaryPerformed(InputAction.CallbackContext context) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
        {
            GameObject go = Instantiate(prefabs[selectedPrefab], hit.point, Quaternion.identity);
            go.name += " _instantiated";
            
            spawnedItems.Add(go);
        } 
    }

    // Primary button released
    void PrimaryCancelled(InputAction.CallbackContext context) {
                
    }

    void SecondaryPerformed(InputAction.CallbackContext context) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
        {
            spawnedItems.Remove(hit.transform.gameObject);
            Destroy(hit.transform.gameObject);
            
        }   
    }

    void SecondaryCancelled(InputAction.CallbackContext context) {
                
    }
}