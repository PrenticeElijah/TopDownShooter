using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    
    public float speed;     // the enemy's speed
    public int health;      // the enemy's health. the enemy will deactivate if <= 0

    protected Rigidbody2D enemyRig;   // enemy's rigidbody
    protected Animator enemyAnim;
    
    public GameObject player;

    public GameManager gameManager;     // the game manager

    // Start is called before the first frame update
    void Start()
    {
        enemyRig = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();      // get the game manager in the scene
    }

    // Update is called once per frame
    void Update(){}

    void FixedUpdate()
    {
        Animation();
        if(player != null)
            AttackPlayer();
    }

    public abstract void AttackPlayer();        // find and attack the player
    public abstract void Health(int damage);    // decrement health and alter the enemy's behavior
    public abstract void Animation();           // handles animations of the enemy

    
    // OnCollisionEnter2D is called when the collider of this object collides with another object's collider
    void OnCollisionEnter2D(Collision2D collided)
    {
        if(collided.gameObject.tag == "Player")
        {
            collided.gameObject.GetComponent<Player>().health--;    // reduce the player's health
            gameManager.CountHealth();      // update the health UI text
            // Debug.Log("Collided");      
        }
    }
}