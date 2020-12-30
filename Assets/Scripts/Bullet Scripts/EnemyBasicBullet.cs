using UnityEngine;

public class EnemyBasicBullet : Bullet
{
    // OnCollisionEnter2D is called when the collider of this object collides with another object's collider
    void OnCollisionEnter2D(Collision2D collided)
    {
        if(collided.gameObject.tag == "Player")
        {
            collided.gameObject.GetComponent<Player>().health--;    // reduce the player's health
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