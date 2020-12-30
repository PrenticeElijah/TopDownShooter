using UnityEngine;

public class PlayerBullet : Bullet
{
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