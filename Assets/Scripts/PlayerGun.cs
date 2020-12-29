using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    
    public Player player;               // the player holding the gun
    public GameObject bullet;           // the bullet currently being fired
    public ObjectPooling playerPool;    // the pool from which to pull player bullets from
    
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject.GetComponentInParent<Player>();    // find the parent player
    }

    // Update is called once per frame
    void Update()
    {
        GunPosition();      // change the position of the gun
        Shoot();            // shoot bullets from the gun
    }
    
    // GunPosition changes the position of the gun based on the arrow key pressed by the player
    void GunPosition()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.position =  player.transform.position + new Vector3(-1,0.5f,0);   // place the gun to the left of the player
        else if(Input.GetKey(KeyCode.RightArrow))
            transform.position =  player.transform.position + new Vector3(1,0.5f,0);    // place the gun to the right of the player
        else if(Input.GetKey(KeyCode.UpArrow))
            transform.position =  player.transform.position + new Vector3(0,1.5f,0);    // place the gun above the player
        else
            transform.position =  player.transform.position + new Vector3(0,-0.5f,0);   // the gun sits below the player by default
    }

    // Shoot fires the player's weapon at enemies
    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            GetBullet(-1,0);    // call a left-moving bullet
        else if(Input.GetKeyDown(KeyCode.RightArrow))
            GetBullet(1,0);     // call a right-moving bullet
        else if(Input.GetKeyDown(KeyCode.UpArrow))
            GetBullet(0,1);     // call an upward-moving bullet
        else if(Input.GetKeyDown(KeyCode.DownArrow))
            GetBullet(0,-1);    // call a downward-moving bullet
    }

    // GetBullet activates available bullets to be fired by the player
    void GetBullet(int xSign, int ySign)
    {
        bullet = playerPool.GetPooledObject();  // return a bullet from the bullet pool
        if(bullet != null)
        {
            bullet.transform.position = this.transform.position;    // place the bullet at the gun's position
            bullet.GetComponent<Bullet>().xDir = xSign;             // set the xDir and yDir variables of the bullet
            bullet.GetComponent<Bullet>().yDir = ySign;
            bullet.SetActive(true);                                 // set the bullet to active
        }
    }
}