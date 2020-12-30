using UnityEngine;

public class Skeleton : Enemy
{
    public float switch_time;

    public override void AttackPlayer()
    {
        if(switch_time <= 0)
        {
            int probability, cutoff;
            probability = Random.Range(0,100);
            cutoff = Random.Range(1,10);
                
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
                if(probability % cutoff == 0)
                    enemyRig.velocity = new Vector2(x * Time.fixedDeltaTime, 0);
                else
                    enemyRig.velocity = new Vector2(0, y * Time.fixedDeltaTime);
            } 
            else if(x != 0 && y == 0)
            {
                enemyRig.velocity = new Vector2(x * Time.fixedDeltaTime, 0);
            }
            else
            {
                enemyRig.velocity = new Vector2(0, y * Time.fixedDeltaTime);
            }
            
            switch_time = Random.Range(0f, 5f);
        }
        else if(transform.position.x > (player.transform.position.x - 0.05f)
            && transform.position.x < (player.transform.position.x + 0.05f))
        {
            float y = 0;
            if(transform.position.y < (player.transform.position.y - 0.05f))
                y = speed;
            else if(transform.position.y > (player.transform.position.y + 0.05f))
                y = -speed;
            enemyRig.velocity = new Vector2(0, y * Time.fixedDeltaTime);
        }
        else if(transform.position.y > (player.transform.position.y - 0.05f)
            && transform.position.y < (player.transform.position.y + 0.05f))
        {
            float x = 0;
            if(transform.position.x < (player.transform.position.x - 0.05f))
                x = speed;
            else if(transform.position.x > (player.transform.position.x + 0.05f))
                x = -speed;
            enemyRig.velocity = new Vector2(x * Time.fixedDeltaTime, 0);
        }
        else
        {
            switch_time -= 0.1f;
        }
    }

    public override void Health(int damage)
    {
        health -= damage;

        if(health <= 0)
            this.gameObject.SetActive(false);
    }

    public override void Animation()
    {
        if(enemyRig.velocity.y > 0)
        {
            enemyAnim.Play("SkeletonUp");
            transform.localScale = new Vector3(1,1,1);
        }
        else if(enemyRig.velocity.y < 0)
        {
            enemyAnim.Play("SkeletonDown");
            transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            enemyAnim.Play("SkeletonSide");
            if(enemyRig.velocity.x < 0)
                transform.localScale = new Vector3(-1,1,1);
            else
                transform.localScale = new Vector3(1,1,1);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            player = obj.gameObject;
        }
    }
}