using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool verticalDoor;       // whether the door is vertical or horizontal
    public float teleportCoord;     // where the player will be teleported (either an x or y position)
    public GameObject player;       // the player object

    public Room thisRoom;           // the room the door is attached to

    // Start is called before the first frame update
    void Start()
    {
        thisRoom = this.GetComponentInParent<Room>();   // find the room the door is attached to
    }

    // Update is called once per frame
    // void Update(){}

    // OnTriggerEnter2D is called when another object enters a trigger attached to this object
    void OnTriggerEnter2D(Collider2D obj)
    {
        // if the player triggers the door...
        if(obj.gameObject == player)
        {
            // if it's a vertical door...
            if(verticalDoor)
                player.transform.position = new Vector3(player.transform.position.x, teleportCoord, 0);     // teleport the player into the next room (above or below)
            else
                player.transform.position = new Vector3(teleportCoord, player.transform.position.y, 0);     // else, teleport the player into the next room (left or right)
        }
    }
}