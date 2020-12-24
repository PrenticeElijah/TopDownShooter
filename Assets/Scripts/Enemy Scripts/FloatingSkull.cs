using UnityEngine;

public class FloatingSkull : Enemy
{
    public override void AttackPlayer()
    {}

    public override void Health(int damage)
    {
        health -= damage;   // decrement the enemy's health

        if (health <= 0)
            this.gameObject.SetActive(false);   // deactivate the Floating Skull when health is less than or equal to 0
    }
}