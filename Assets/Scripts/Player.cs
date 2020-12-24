using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float moveSpeed;         // the speed of the player character
    Rigidbody2D playerRig;          // the player's rigidbody
    
    Animator playerAnim;            // the player's animation controller to handle animation
    public bool isIdle = true;      // indicates whether or not the player is inputing movement commands
    
    /*
        mousePosX and mousePosY hold the x and y coordinates of the mouse on the game screen
        screenW and screenY hold the total width and height of the game screen
    */
    public float mousePosX, mousePosY, screenW, screenY;
    public bool mouseLeft, mouseRight, mouseUp, mouseDown;      // bool variables to show what direction the player is facing
    
    public GameObject Gun;          // the empty object where bullets are instantiated and shot from
    
    // Start is called before the first frame update
    void Start()
    {
        playerRig = GetComponent<Rigidbody2D>();    // get the rigidbody attached to the player
        playerAnim = GetComponent<Animator>();      // get the animation controller attached to the player
        
        screenW = Screen.width;         // get the width of the game screen
        screenY = Screen.height;        // get the height of the game screen
    }

    // Update is called once per frame
    void Update()
    {
        // the player is idle if there is no input from the player to move
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            isIdle = true;
        else
            isIdle = false;
        
        Shoot();                // shoot enemies
        MouseCoordinates();     // get the coordinates of the mouse and where the player is facing
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

    // Shoot fires the player's weapon at enemies
    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }

    // OnGUI handles events that occur over the game GUI
    void OnGUI()
    {
        Event e = Event.current;            // get the mouse position event

        // store the x and y coordinates of the mouse position
        mousePosX = e.mousePosition.x;
        mousePosY = e.mousePosition.y;

        // Debug.Log(e.mousePosition);
    }

    // MouseCoordinates Change the player's direction based on the mouse's position
    void MouseCoordinates()
    {
        if(mousePosX < ((screenW / 2) - (screenW * 0.1)))
        {
            // if the mouse's position is less than the left bounds, then the player is facing left

            if(!mouseLeft)
                transform.localScale = new Vector3(-1, 1, 1);   // flip the player to the left if not facing left

            mouseLeft = true;   mouseRight = false;
            mouseUp = false;    mouseDown = false;
        }
        else if (mousePosX > ((screenW / 2) + (screenW * 0.1)))
        {
            // if the mouse's position is greater than the right bounds, then the player is facing right
            
            if(!mouseRight)
                transform.localScale = new Vector3(1, 1, 1);    // flip the player to the right if not facing right
            
            mouseRight = true;  mouseLeft = false;
            mouseUp = false;    mouseDown = false;
        }
        else
        {
            // if the player is between the left and right bounds, they are not facing either directuon
            mouseLeft = false;  mouseRight = false;

            if(mousePosY < (screenY / 2))
            {
                // the player faces up if the mouse's position is above the center
                mouseUp = true; mouseDown = false;
            }
            else
            {
                // the player faces down if the mouse's position is below the center
                mouseDown = true;   mouseUp = false;
            }
        }
    }

    // Animations plays the appropriate animation dependent on the player's actions and direction
    void Animations()
    {
        if(mouseLeft || mouseRight)
        {
            // if the player is facing left or right and ...
            if (isIdle)
                playerAnim.Play("PlayerIdleSide");      // ... the player is idle, the side idle animation plays
            else
                playerAnim.Play("PlayerWalkSide");      // ... the player is not idle, the side walk animation plays
        }
        else if (mouseUp)
        {
            // if the player is facing upward and ...
            if (isIdle)
                playerAnim.Play("PlayerIdleUp");        // ... the player is idle, the up idle animation plays
            else
                playerAnim.Play("PlayerWalkUp");        // ... the player is not idle, the up walk animation plays
        }
        else
        {
            // if the player is facing downward and ...
            if (isIdle)
                playerAnim.Play("PlayerIdleDown");      // ... the player is idle, the down idle animation plays
            else
                playerAnim.Play("PlayerWalkDown");      // ... the player is not idle, the down walk animation plays
        }
    }
}