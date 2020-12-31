using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Player player;               // the player holding the gun
    public GameObject bullet;           // the bullet currently being fired
    public ObjectPooling playerPool;    // the pool from which to pull player bullets from

    public float fireRate = 1f;     // the rate of fire for the player
    public float fireTime = 0;      // the timer for when the player can fire again
    
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject.GetComponentInParent<Player>();    // find the parent player
    }

    // Update is called once per frame
    // void Update(){}

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        Shoot();
    }

    // Shoot fires the player's weapon at enemies
    void Shoot()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow)
        || Input.GetKeyUp(KeyCode.RightArrow)
        || Input.GetKeyUp(KeyCode.DownArrow)
        || Input.GetKeyUp(KeyCode.UpArrow))
        {
            fireTime = fireRate/2;    // if the player releases a shooting command, start the timer from half the fire rate
        }
        
        // if the timer equals the rate, the player may shoot
        if(fireTime >= fireRate)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                GetBullet(-1,0);    // call a left-moving bullet if the left arrow button is pressed
                fireTime = 0;       // reset the timer
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                GetBullet(1,0);     // call a right-moving bullet if the right arrow button is pressed
                fireTime = 0;       // reset the timer
            }
            else if(Input.GetKey(KeyCode.UpArrow))
            {
                GetBullet(0,1);     // call an upward-moving bullet if the up arrow button is pressed
                fireTime = 0;       // reset the timer
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                GetBullet(0,-1);    // call a downward-moving bullet if the down arrow button is pressed
                fireTime = 0;       // reset the timer
            }
        }
        else
        {
            fireTime += 0.1f;   // increment the shot counter
        }
    }

    // GetBullet activates available bullets to be fired by the player
    void GetBullet(int xSign, int ySign)
    {
        bullet = playerPool.GetPooledObject();  // return a bullet from the player bullet pool
        if(bullet != null)
        {
            bullet.transform.position = this.transform.position;    // place the bullet at the gun's position
            bullet.GetComponent<Bullet>().xDir = xSign;             // set the xDir and yDir variables of the bullet
            bullet.GetComponent<Bullet>().yDir = ySign;
            bullet.SetActive(true);                                 // set the bullet to active
        }
    }
}