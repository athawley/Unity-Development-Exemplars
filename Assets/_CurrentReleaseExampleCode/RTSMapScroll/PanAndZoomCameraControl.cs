using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. Add the input system package
using UnityEngine.InputSystem;
// 2. Add the cinemachine package
using Cinemachine;

public class PanAndZoomCameraControl : MonoBehaviour
{
    // 3. The input provider for handling mouse input to the camera
    [SerializeField]
    private CinemachineInputProvider _inputProvider;
    // 4. The virtual camera for the camera
    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;

    // 5. Transform of the camera
    [SerializeField]
    private Transform _cameraTransform;

    // 6. When the mouse is in this percent of the edge scroll the screen
    [SerializeField]
    private float _scrollBorderPercent = 0.05f;

    // 7. Speed to pan the camera
    [SerializeField]
    private float _panSpeed = 50.0f;

    // 8. Speed to zoom the camera (change field of view)
    [SerializeField]
    private float _zoomSpeed= 5.0f;

    // Update is called once per frame
    void Update()
    {
        // 16. Setup the mouse x and y inputs position and the z (scroll) values
        float x = _inputProvider.GetAxisValue(0);
        float y = _inputProvider.GetAxisValue(1);
        float z = _inputProvider.GetAxisValue(2);

        // 17. If the mouse has moved in x and y position move the camera
        if(x !=0 || y != 0) {
            PanScreenInDirection(x,y);
        }
        // 21. If z (scrollwheel) has been pressed adjust the field of view.
        if(z !=0) {
            ZoomScreen(z);
        }
    }

    // 9. Pan the screen in the x and y direction
    public void PanScreenInDirection(float x, float y) {
        // 10. Set the panDirection to 0,0,0
        Vector3 panDirection = Vector3.zero;

        /* 11.
        If the y mouse position is within the percent of the top border pan the screen up
        */
        if(y >= Screen.height * (1 - _scrollBorderPercent)) {
            panDirection.z += 1;
        } else 
        /* 12.
        If the y mouse position is within the percent of the bottom border pan the screen down
        */
        if(y <= Screen.height * _scrollBorderPercent) {
            panDirection.z -= 1;
        }
        /* 13.
        If the x mouse position is within the percent of the left border pan the screen left
        */
        if(x >= Screen.width * (1 - _scrollBorderPercent)) {
            panDirection.x += 1;
        } else 
        /* 14.
        If the x mouse position is within the percent of the left border pan the screen left
        */
        if(x <= Screen.width * _scrollBorderPercent) {
            panDirection.x -= 1;
        }

        /* 15. 
        Move the camera transform to the new panDirection position.
        Lerp takes the current position, the new position and then the time scale to move
        */
        _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, 
                                                _cameraTransform.position + panDirection * _panSpeed,
                                                Time.deltaTime
                                                );
    }

    /* 18. 
    Similar to 15. but for the zoom in and out
    We adjust the field of view of the camera rather than moving the z axis
    */
    public void ZoomScreen(float z) {
        // 19. Get the camera lens field of view
        float fieldOfView = _virtualCamera.m_Lens.FieldOfView;
        // 20. Update the field of view to the new z position and adjust by the _zoomSpeed
        _virtualCamera.m_Lens.FieldOfView = fieldOfView = Mathf.Lerp(fieldOfView,
                                                                    fieldOfView + z,
                                                                    _zoomSpeed * Time.deltaTime
                                                                    );
    }
}