using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float bulletSpeed;   // how quickly the bullet moves
    public float xDir, yDir;    // the x and y directions the bullet travels
    public int damage;          // how much damage the bullet inflicts

    protected Rigidbody2D bulletRig;    // the bullet rigidbody, allows it to move

    // Start is called before the first frame update
    void Start()
    {
        bulletRig = GetComponent<Rigidbody2D>();    // get the rigidbody attached to the bullet
    }

    // Update is called once per frame
    // void Update(){}

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        Fire();
    }

    public abstract void Fire();    // Fire is called to change the bullet's position based on its speed and direction
}