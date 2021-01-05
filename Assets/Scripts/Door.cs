using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool verticalDoor;
    public float teleportCoord;
    public GameObject player;

    public Room thisRoom;

    // Start is called before the first frame update
    void Start()
    {
        thisRoom = this.GetComponentInParent<Room>();
    }

    // Update is called once per frame
    // void Update(){}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject == player)
        {
            if(verticalDoor)
                player.transform.position = new Vector3(player.transform.position.x, teleportCoord, 0);
            else
                player.transform.position = new Vector3(teleportCoord, player.transform.position.y, 0);
        }
    }
}