using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletSpeed;   // how quickly the bullet moves
    public float xDir, yDir;    // the x and y directions the bullet travels
    public int damage;          // how much damage the bullet inflicts
    public string targetTag;    // indicates the target the bullet can inflict damage on

    // Start is called before the first frame update
    // void Start(){}

    // Update is called once per frame
    // void Update(){}

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        // change the bullets position based on its speed and direction
        transform.position += new Vector3(xDir * bulletSpeed, yDir * bulletSpeed, 0);
    }

    // OnCollisionEnter2D is called when the collider of this object collides with another object's collider
    void OnCollisionEnter2D(Collision2D collided)
    {
        if(collided.gameObject.tag == "Enemy")
        {
            collided.gameObject.GetComponent<Enemy>().Health(damage);    // reduce the enemy's health
            // Debug.Log("Collided");
            this.gameObject.SetActive(false);           // deactivate the bullet
        }
        else if(collided.gameObject.tag == "Tiles")
        {
            // Debug.Log("Collided");
            this.gameObject.SetActive(false);           // deactivate the bullet
        }
    }
}