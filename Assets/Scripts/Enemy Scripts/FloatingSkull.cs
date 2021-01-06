using UnityEngine;

public class FloatingSkull : Enemy
{
    public override void AttackPlayer()
    {
        if (transform.position != player.transform.position)
        {
            float x;    // the x velocity
            if(transform.position.x < (player.transform.position.x - 0.05f))
                x = speed;      // if the player is to the right of the skeleton, horizontal velocity is positive
            else if(transform.position.x > (player.transform.position.x + 0.05f))
                x = -speed;     // if the player is to the left of the skeleton, horizontal velocity is negative
            else
                x = 0;
            
            float y;    // the y velocity
            if(transform.position.y < (player.transform.position.y - 0.05f))
                y = speed;      // if the player is above the skeleton, vertical velocity is positive
            else if(transform.position.y > (player.transform.position.y + 0.05f))
                y = -speed;     // if the player is below the skeleton, vertical velocity is negative
            else
                y = 0;
            
            // if the skull is moving vertically and horizontally
            if(x != 0 && y != 0)
            {
                x /= 2f;    // reduce the x and y velocities to reduce the diagonal speed
                y /= 2f;
            }
            enemyRig.velocity = new Vector2(x * Time.fixedDeltaTime, y * Time.fixedDeltaTime);      // move the skull
        }
    }

    public override void Animation(){}

    public override void Health(int damage)
    {
        health -= damage;   // decrement the skull's health

        if (health <= 0)
            EnemyDeath();   // if the skull's health is 0 or below, call EnemyDeath
    }
}