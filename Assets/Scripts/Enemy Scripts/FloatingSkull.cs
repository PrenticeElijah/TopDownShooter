using UnityEngine;

public class FloatingSkull : Enemy
{
    public override void AttackPlayer()
    {
        if (transform.position != player.transform.position)
        {
            float x;
            if(transform.position.x < (player.transform.position.x - 0.05f))
                x = speed;
            else if(transform.position.x > (player.transform.position.x + 0.05f))
                x = -speed;
            else
                x = 0;
            
            float y;
            if(transform.position.y < (player.transform.position.y - 0.05f))
                y = speed;
            else if(transform.position.y > (player.transform.position.y + 0.05f))
                y = -speed;
            else
                y = 0;
            
            if(x != 0 && y != 0)
            {
                x /= 2f;
                y /= 2f;
            }
            enemyRig.velocity = new Vector2(x * Time.fixedDeltaTime, y * Time.fixedDeltaTime);
        }
    }

    public override void Animation(){}

    public override void Health(int damage)
    {
        health -= damage;   // decrement the enemy's health

        if (health <= 0)
            this.gameObject.SetActive(false);   // deactivate the Floating Skull when health is less than or equal to 0
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            player = obj.gameObject;
        }
    }
}