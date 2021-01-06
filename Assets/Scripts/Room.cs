using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool hasEnemies;             // whether or not the room has enemies
    public List<Enemy> roomEnemies;     // the list of enemies in the room
    
    public Player player;               // the player character      

    public CameraMovement cam;          // the camera

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();        // find the player character in the scene
    }

    // Update is called once per frame
    // void Update(){}

    // OnTriggerEnter2D is called when another object enters a trigger attached to this object
    void OnTriggerEnter2D(Collider2D obj)
    {
        // if the player walks into the room...
        if(obj.gameObject.tag == "Player")
        {   
            cam.FindRoom(this.transform.position);      // move the camera to the room
            if(hasEnemies)
                ActivateEnemy();    // activate enemies if the room has any
        }
    }

    // OnTriggerExit2D is called when another object exits a trigger attached to this object
    void OnTriggerExit2D(Collider2D exited)
    {
        // if the player leaves the room and the room has enemies...
        if(exited.gameObject.tag == "Player"
        && hasEnemies == true)
        {
            ResetEnemy();   // reset the enemies
        }
        else if(exited.gameObject.tag == "Bullet")
        {
            exited.gameObject.SetActive(false);     // deactivate bullets that fly out of the room
        }
    }

    // ActivateEnemy is called to set the enemies in a room to active
    void ActivateEnemy()
    {
        // iterate through each enemy in the room's list
        for(int i = 0; i < roomEnemies.Count; i++)
        {
            // if the enemy is still alive (health is above 0)
            if(!roomEnemies[i].isDead)
            {
                roomEnemies[i].gameObject.SetActive(true);  // set the enemy to active
            }
        }
    }

    // ResetEnemy is called to reposition remaining enemies in a room the player has left
    void ResetEnemy()
    {
        // iterate through each enemy in the room's list
        for(int i = 0; i < roomEnemies.Count; i++)
        {
            // if the enemy is still alive...
            if(!roomEnemies[i].isDead)
            {
                roomEnemies[i].gameObject.transform.position = roomEnemies[i].startPos;     // place the enemy back in its starting position
                roomEnemies[i].gameObject.SetActive(false);             // set teh enemy to inactive
            }
        }
    }
}