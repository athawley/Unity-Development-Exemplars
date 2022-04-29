using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraInitialiser : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private GameObject _virtualPlayerCam;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementCine3rdLocalMP[] playerMovements = FindObjectsOfType<PlayerMovementCine3rdLocalMP>();

        int layer = playerMovements.Length + 10;
        _virtualPlayerCam.layer = layer;

         var bitMask = (1 << layer)
             | (1 << 0)
             | (1 << 1)
             | (1 << 2)
             | (1 << 4)
             | (1 << 5)
             | (1 << 8);

        _cam.cullingMask = bitMask;
        _cam.gameObject.layer = layer;
    }
}
