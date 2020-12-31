using UnityEngine;

public class PlayerBullet : Bullet
{
    
    public override void Fire()
    {
        // move the bullet according to x and y direction
        // for the player, xDir and yDir will always be -1, 0, or 1
        bulletRig.velocity = new Vector2(xDir * bulletSpeed, yDir * bulletSpeed);
    }
    
    // OnCollisionEnter2D is called when the collider of this object collides with another object's collider
    void OnCollisionEnter2D(Collision2D collided)
    {
        if(collided.gameObject.tag == "Enemy")
        {
            collided.gameObject.GetComponent<Enemy>().Health(damage);    // reduce the enemy's health
            // Debug.Log("Collided");
        }
        this.gameObject.SetActive(false);           // deactivate the bullet
    }
}