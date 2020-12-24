using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    
    // Cursor Script by BlackThornProd: https://www.youtube.com/watch?v=cCKlMAwvQcI
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;     // hide the mouse icon
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // get the position of the mouse
        transform.position = cursorPos;         // match the aiming cursor's position with the mouse position
    }
}