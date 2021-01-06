using UnityEngine;

public class EnemyBasicBullet : Bullet
{

    public override void Fire()
    {
        // the idea to use Vector2.Normalize() came from a tutorial by CouchFerret:
        // https://www.youtube.com/watch?v=_QVAC69su3Q&ab_channel=CouchFerretmakesGames
        
        Vector2 shotDirection = new Vector2(xDir,yDir);     // get the direction to fire the bullet
        shotDirection.Normalize();                          // Normalize keeps the direction of the Vector, but the magnitude is of 1
        bulletRig.velocity = shotDirection * bulletSpeed;   // fire the bullet at the specified speed
    }
    
    // OnCollisionEnter2D is called when the collider of this object collides with another object's collider
    void OnCollisionEnter2D(Collision2D collided)
    {
        // if the bullet collides with the player...
        if(collided.gameObject.tag == "Player")
        {
            collided.gameObject.GetComponent<Player>().health--;    // reduce the player's health
            gameManager.CountHealth();      // update the health UI text
            // Debug.Log("Collided");      
        }
        this.gameObject.SetActive(false);       // deactivate the bullet
    }
}