using UnityEngine;

public class Skeleton : Enemy
{
    float switch_time = 0;      // the time before the skeleton changes direction

    public override void AttackPlayer()
    {
        // if it is time to change direction...
        if(switch_time <= 0)
        {
            // the skeleton will only move horizontally if probability is divisible by cutoff
            // ^-------------------------^ vertically otherwise
            int probability, cutoff;
            probability = Random.Range(0,100);      
            cutoff = Random.Range(1,10);
                
            float x = 0;    // the x velocity
            if(transform.position.x < (player.transform.position.x - 0.05f))
                x = speed;      // if the player is to the right of the skeleton, horizontal velocity is positive
            else if(transform.position.x > (player.transform.position.x + 0.05f))
                x = -speed;     // if the player is to the left of the skeleton, horizontal velocity is negative
            else
                x = 0;          // horizontal velocity is 0
            
            float y = 0;    // the y velocity
            if(transform.position.y < (player.transform.position.y - 0.05f))
                y = speed;      // if the player is above the skeleton, vertical velocity is positive
            else if(transform.position.y > (player.transform.position.y + 0.05f))
                y = -speed;     // if the player is below the skeleton, vertical velocity is negative
            else
                y = 0;          // vertical velocity is 0
            
            // if the x and y velocities are not 0
            if(x != 0 && y != 0)
            {
                // if probability is divisible by cutoff...
                if(probability % cutoff == 0)
                    enemyRig.velocity = new Vector2(x * Time.fixedDeltaTime, 0);    // ...the skeleton will only move horizontally
                else
                    enemyRig.velocity = new Vector2(0, y * Time.fixedDeltaTime);    // otherwise, the skeleton will only move vertically
            } 
            else if(x != 0 && y == 0)
            {
                enemyRig.velocity = new Vector2(x * Time.fixedDeltaTime, 0);        // if the vertical velocity is 0, move horizontally
            }
            else
            {
                enemyRig.velocity = new Vector2(0, y * Time.fixedDeltaTime);        // otherwise, move vertically
            }
            
            switch_time = Random.Range(0f, 5f);     // reset the switch timer
        }
        else if(transform.position.x > (player.transform.position.x - 0.05f)
            && transform.position.x < (player.transform.position.x + 0.05f))
        {
            // if the skeleton and player are lined up horizontally...

            float y = 0;    // the y velocity
            if(transform.position.y < (player.transform.position.y - 0.05f))
                y = speed;      // if the player is above the skeleton, vertical velocity is positive
            else if(transform.position.y > (player.transform.position.y + 0.05f))
                y = -speed;     // if the player is below the skeleton, vertical velocity is negative
            enemyRig.velocity = new Vector2(0, y * Time.fixedDeltaTime);    // move the skeleton vertically
        }
        else if(transform.position.y > (player.transform.position.y - 0.05f)
            && transform.position.y < (player.transform.position.y + 0.05f))
        {   
            // if the skeleton and player are lined up vertically

            float x = 0;    // the x velocity
            if(transform.position.x < (player.transform.position.x - 0.05f))
                x = speed;      // if the player is to the right of the skeleton, horizontal velocity is positive
            else if(transform.position.x > (player.transform.position.x + 0.05f))
                x = -speed;     // if the player is to the left of the skeleton, horizontal velocity is negative
            enemyRig.velocity = new Vector2(x * Time.fixedDeltaTime, 0);    // move the skeleton horizontally
        }
        else
        {
            switch_time -= 0.1f;    // otherwise, maintain the current velocity and decrement the switch timer
        }
    }

    public override void Health(int damage)
    {
        health -= damage;   // decrement the skeleton's health

        if(health <= 0)
            EnemyDeath();
    }

    public override void Animation()
    {
        if(enemyRig.velocity.y > 0)
        {
            enemyAnim.Play("SkeletonUp");               // if the skeleton is moving up, play the up movement animation
            transform.localScale = new Vector3(1,1,1);
        }
        else if(enemyRig.velocity.y < 0)
        {
            enemyAnim.Play("SkeletonDown");             // if the skeleton is moving down, play the down movement animation
            transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            enemyAnim.Play("SkeletonSide");             // otherwise, play the side movement animation
            if(enemyRig.velocity.x < 0)
                transform.localScale = new Vector3(-1,1,1);     // invert the skeleton if moving to the left
            else
                transform.localScale = new Vector3(1,1,1);
        }
    }
}