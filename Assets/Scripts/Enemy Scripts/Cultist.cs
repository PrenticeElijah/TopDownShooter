using UnityEngine;

public class Cultist : Enemy
{
    int phase = 1;                  // the cultist's attack phase
    float switch_time = 0;          // the time before the cultist changes direction
    public bool withinDistance;     // if the player is within shooting distance of the cultist

    public GameObject cultistGun;   // the empty object where bullets are instantiated and shot from on the cultist

    public override void AttackPlayer()
    {
        if(!withinDistance)
        {
            FollowPlayer();     // follow the player if not within shooting distance
        }
        else
        {
            enemyRig.velocity = new Vector2(0,0);   // stop the cultist
            if(phase == 1)
                AttackPhase1();     // phase one attack
            else if(phase == 2)
                AttackPhase2();     // phase two attack
            else
                Debug.Log("Cultist Phase Error");
        }
    }

    public override void Health(int damage)
    {
        health -= damage;   // decrement the cultist's health

        if(health <= 0)
            this.gameObject.SetActive(false);   // deactivate the cultist when health is less than or equal to 0
        //else if(health <= 10)
            //phase = 2;
    }

    public override void Animation()
    {
        if(!withinDistance)
        {
            if(enemyRig.velocity.y > 0)
            {
                enemyAnim.Play("CultistWalkUp");
                transform.localScale = new Vector3(1,1,1);
            }
            else if(enemyRig.velocity.y < 0)
            {
                enemyAnim.Play("CultistWalkDown");
                transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                enemyAnim.Play("CultistWalkSide");
                if(enemyRig.velocity.x < 0)
                    transform.localScale = new Vector3(-1,1,1);
                else
                    transform.localScale = new Vector3(1,1,1);
            }
        }
        else
        {
            if((player.transform.position.x <= (transform.position.x + 3.5f))
                && (player.transform.position.x > transform.position.x))
            {
                enemyAnim.Play("CultistShootSide");
                transform.localScale = new Vector3(1,1,1);
            }
            else if((player.transform.position.x >= (transform.position.x - 3.5f))
                && (player.transform.position.x < transform.position.x))
            {
                enemyAnim.Play("CultistShootSide");
                transform.localScale = new Vector3(-1,1,1);
            }
            else if (player.transform.position.y > transform.position.y)
            {
                enemyAnim.Play("CultistShootUp");
                transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                enemyAnim.Play("CultistShootDown");
                transform.localScale = new Vector3(1,1,1);
            }
        }
    }

    // FollowPlayer is called when the player is not within the shooting distance of the culist
    // uses the same code as the skeleton's Attack function
    void FollowPlayer()
    {
        if(switch_time <= 0)
        {
            int probability, cutoff;
            probability = Random.Range(0,100);
            cutoff = Random.Range(1,10);
                
            float x = 0;
            if(transform.position.x < (player.transform.position.x - 0.05f))
                x = speed;
            else if(transform.position.x > (player.transform.position.x + 0.05f))
                x = -speed;
            else
                x = 0;
            
            float y = 0;
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

    void Fire(float targetX, float targetY)
    {}

    void AttackPhase1(){}

    void AttackPhase2(){}
    
    // OnTriggerEnter2D is called when another object enters a trigger attached to this object
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
            withinDistance = true;
    }

    // OnTriggerExit2D is called when another object exits a trigger attached to this object
    void OnTriggerExit2D(Collider2D obj)
    {
        
        if(obj.gameObject.tag == "Player")
            withinDistance = false;
    }
}