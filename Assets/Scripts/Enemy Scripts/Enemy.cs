using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    
    public int health;      // the enemy's health. the enemy will deactivate if <= 0

    Rigidbody2D enemyRig;   // enemy's rigidbody
    
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
    }

    public abstract void AttackPlayer();        // find and attack the player
    public abstract void Health(int damage);    // decrement health and alter the enemy's behavior
}