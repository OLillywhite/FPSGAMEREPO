using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour
{
    void Update()
    {
        if (PauseMenu.GameIsPaused == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked; // Cursor is now locked to screen
        }
        if (PauseMenu.GameIsPaused == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; // Cursor is now locked to screen
        }
    }
        
}
