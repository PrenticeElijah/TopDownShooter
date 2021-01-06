using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // public GameObject playerChar;       // the player that the camera will follow
    
    // Start is called before the first frame update
    void Start()
    {
        // playerChar = GameObject.FindWithTag("Player");      // find the player object
    }

    // Update is called once per frame
    void Update(){}

    // FindRoom is called when the player enters another room so that teh camera is positioned correctly
    public void FindRoom(Vector3 roomCoord)
    {
        transform.position = roomCoord - new Vector3(0,0,10);       // the camera is set directly above the room
    }

    /*
    void FollowPlayer()
    {
        transform.position = new Vector3(playerChar.transform.position.x, playerChar.transform.position.y, -10);    // match the camera's position with the player's
    }
    */
}