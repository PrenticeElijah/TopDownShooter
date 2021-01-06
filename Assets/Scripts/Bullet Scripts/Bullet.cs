using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float bulletSpeed;   // how quickly the bullet moves
    public float xDir, yDir;    // the x and y directions the bullet travels
    public int damage;          // how much damage the bullet inflicts

    protected Rigidbody2D bulletRig;    // the bullet rigidbody, allows it to move

    public GameManager gameManager;     // the game manager

    // Start is called before the first frame update
    void Start()
    {
        bulletRig = GetComponent<Rigidbody2D>();            // get the rigidbody attached to the bullet
        gameManager = FindObjectOfType<GameManager>();      // get the game manager in the scene
    }

    // Update is called once per frame
    // void Update(){}

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        Fire();     // move the bullet
    }

    public abstract void Fire();    // Fire is called to change the bullet's position based on its speed and direction
}