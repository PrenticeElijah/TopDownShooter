using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    
    public float speed;     // the enemy's speed
    public int health;      // the enemy's health. the enemy will deactivate if <= 0

    protected Rigidbody2D enemyRig;     // enemy's rigidbody
    protected Animator enemyAnim;       // enemy's animator
    
    public Player player;           // the player character

    public GameManager gameManager;     // the game manager

    public Vector3 startPos;        // the enemy's starting position in the scene/room
    public bool isDead = false;     // whether or not the enemy can attack (false when health is greater than 0)

    public int reward;      // how much gold the player is awarded for defeating an enemy

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();                // find the player character in the scene
        enemyRig = GetComponent<Rigidbody2D>();             // get the enemy's attached Rigidbody2D
        enemyAnim = GetComponent<Animator>();               // get the enemy's attached Animator
        gameManager = FindObjectOfType<GameManager>();      // find the game manager in the scene
    }

    // Update is called once per frame
    // void Update(){}

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        Animation();            // play the appropriate animation(s) for the enemy
        if(player != null)
            AttackPlayer();     // attack the player
    }

    public abstract void AttackPlayer();        // find and attack the player
    public abstract void Health(int damage);    // decrement health and alter the enemy's behavior
    public abstract void Animation();           // handles animations of the enemy

    // EnemyDeath is called when the enemy's health is less than or equal to 0
    protected void EnemyDeath()
    {
        isDead = true;                      // enemy is considered dead
        this.gameObject.SetActive(false);       // deactivate the enemy
        gameManager.CountTreasure(reward);      // reward the player
    }
    
    // OnCollisionEnter2D is called when the collider of this object collides with another object's collider
    void OnCollisionEnter2D(Collision2D collided)
    {
        // if the enemy and the player come into contact...
        if(collided.gameObject.tag == "Player")
        {
            collided.gameObject.GetComponent<Player>().health--;    // reduce the player's health
            gameManager.CountHealth();      // update the health UI text
            // Debug.Log("Collided");      
        }
    }
}