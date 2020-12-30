using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;              // the health of the player, reset after reaching 0

    public float moveSpeed;         // the speed of the player character
    Rigidbody2D playerRig;          // the player's rigidbody
    
    Animator playerAnim;            // the player's animation controller to handle animation
    public bool isIdle = true;      // indicates whether or not the player is inputing movement commands
    
    public bool faceLeft, faceRight, faceUp, faceDown;      // bool variables to show what direction the player is facing
    
    public GameObject Gun;          // the empty object where bullets are instantiated and shot from
    
    // Start is called before the first frame update
    void Start()
    {
        playerRig = GetComponent<Rigidbody2D>();    // get the rigidbody attached to the player
        playerAnim = GetComponent<Animator>();      // get the animation controller attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        // the player is idle if there is no input from the player to move
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            isIdle = true;
        else
            isIdle = false;

        Animations();           // handle animations
    }

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        PlayerMovement();       // moving the player
    }

    // PlayerMovement handles the player's velocity, allows the player to move around
    void PlayerMovement()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            // move the player diagonally
            // lower the move speed to keep the player's velocity down
            playerRig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * (moveSpeed / 1.5f), Input.GetAxisRaw("Vertical") * (moveSpeed / 1.5f));
        }
        else if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            // move the player either horizontally or vertically
            playerRig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
        }
        else
        {
            // keep the player still
            playerRig.velocity = new Vector2(0,0);
        }
    }

    // Animations plays the appropriate animation dependent on the player's actions and direction
    void Animations()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnim.Play("PlayerAttackSide");
            transform.localScale = new Vector3(-1,1,1);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.Play("PlayerAttackSide");
            transform.localScale = new Vector3(1,1,1);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            playerAnim.Play("PlayerAttackUp");
            transform.localScale = new Vector3(1,1,1);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            playerAnim.Play("PlayerAttackDown");
            transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                // if the player is moving left or right, the side walk animation plays
                playerAnim.Play("PlayerWalkSide");
                transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"),1,1);
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                // if the player is moving upward, the up walk animation plays
                playerAnim.Play("PlayerWalkUp");
                transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                // if the player is facing downward and ...
                if (isIdle)
                    playerAnim.Play("PlayerIdleDown");      // ... the player is idle, the down idle animation plays
                else
                    playerAnim.Play("PlayerWalkDown");      // ... the player is not idle, the down walk animation plays

                transform.localScale = new Vector3(1,1,1);
            }
        }
    }
}