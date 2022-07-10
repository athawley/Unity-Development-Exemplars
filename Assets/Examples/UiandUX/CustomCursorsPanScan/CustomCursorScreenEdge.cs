/*
    This script relies on the Pan and Zoom Camera Control lesson having been completed.
    https://learnictnow.com/lesson/rts-style-pan-and-zoom-camera-using-cinemachine/
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. Cinemachine objects
using Cinemachine;

public class CustomCursorScreenEdge : MonoBehaviour
{
    // 2. Cinemachine new input provider
    [SerializeField]
    private CinemachineInputProvider _inputProvider;

    // 3. Percentage of the screen border to change icon / cursor at
    [SerializeField]
    private float _scrollBorderPercent = 0.05f;

    /* 4. 
    Array to store icons for the cursors
    0 - Up
    1 - Upper Right
    2 - Right
    3 - Lower Right
    4 - Down
    5 - Lower Left
    6 - Left
    7 - Upper Left
    */
    public Texture2D[] cursorTextures;

    // 5. Default cursor mode for Unity
    public CursorMode cursorMode = CursorMode.Auto;

    /* 6. 
    Origin point (where the mouse clicks) for the cursor
    Default is 0,0
    */
    public Vector2 hotSpot = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        // 7. x and y mouse position for the CineMachine input Provider
        float x = _inputProvider.GetAxisValue(0);
        float y = _inputProvider.GetAxisValue(1);

        /* 8.
        The next set of nested if statements handles which cursor to load.
        It needs to check if the cursor is at the top of the screen, bottom, left, or right.
        If the cursor is also at the top or the bottom it also needs to check if the
        cursor is in the left or right corner as well.
        */

        // 9. If at the top of the screen
        if(y >= Screen.height * (1 - _scrollBorderPercent)) {
            // 10. Check if on the right as well
            if(x >= Screen.width * (1 - _scrollBorderPercent)) {
                // 11. If so change the cursor to top right
                Cursor.SetCursor(cursorTextures[1], Vector2.zero, cursorMode);
            } else
            // 12. Check if in top left as well
            if(x <= Screen.width * _scrollBorderPercent) {
                Cursor.SetCursor(cursorTextures[7], Vector2.zero, cursorMode);
            } else {
                // 13. Otherwise the cursor is at the top so display that cursor
                Cursor.SetCursor(cursorTextures[0], Vector2.zero, cursorMode);
            }
        } else 
        // 14. Check if at the bottom of the screen
        if(y <= Screen.height * _scrollBorderPercent) {
            // 15. Check if also in the lower right
            if(x >= Screen.width * (1 - _scrollBorderPercent)) {
                Cursor.SetCursor(cursorTextures[3], Vector2.zero, cursorMode);
            } else
            // 16. Check if also in the lower left
            if(x <= Screen.width * _scrollBorderPercent) {
                Cursor.SetCursor(cursorTextures[5], Vector2.zero, cursorMode);
            } else {
                // 17. In the bottom only
                Cursor.SetCursor(cursorTextures[4], Vector2.zero, cursorMode);
            }
        } else 
        /* 18. 
        Check if on the right 
        (we don't need to check the corners as we did this as well)
        */
        if(x >= Screen.width * (1 - _scrollBorderPercent)) {
            Cursor.SetCursor(cursorTextures[2], Vector2.zero, cursorMode);
        } else 
        // 19. Check if on the left
        if(x <= Screen.width * _scrollBorderPercent) {
            Cursor.SetCursor(cursorTextures[6], Vector2.zero, cursorMode);
        } else {
            /* 20.
             If none of these are true the cursor is not in the scroll area.
             So display the default cursor.
            */
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}
