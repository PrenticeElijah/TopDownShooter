using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float moveSpeed;
    Rigidbody2D playerRig;
    
    Animator playerAnim;
    public bool isIdle = true;
    
    public float mousePosX, mousePosY, screenW, screenY;
    public bool mouseLeft, mouseRight, mouseUp, mouseDown;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRig = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        
        screenW = Screen.width;
        screenY = Screen.height;
        // Debug.Log(Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            isIdle = true;
        else
            isIdle = false;
        
        Shoot();
        MouseCoordinates();
        Animations();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            playerRig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * (moveSpeed / 1.5f), Input.GetAxisRaw("Vertical") * (moveSpeed / 1.5f));
        }
        else if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            playerRig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
        }
        else
        {
            playerRig.velocity = new Vector2(0,0);
        }
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            Debug.Log("Shooting");
    }

    void OnGUI()
    {
        Event e = Event.current;
        mousePosX = e.mousePosition.x;
        mousePosY = e.mousePosition.y;

        // Debug.Log(e.mousePosition);
    }

    void MouseCoordinates()
    {
        if(mousePosX < ((screenW / 2) - (screenW * 0.05)))
        {
            if(!mouseLeft)
                transform.localScale = new Vector3(-1, 1, 1);

            mouseLeft = true;   mouseRight = false;
            mouseUp = false;    mouseDown = false;
        }
        else if (mousePosX > ((screenW / 2) + (screenW * 0.05)))
        {
            if(!mouseRight)
                transform.localScale = new Vector3(1, 1, 1);
            
            mouseRight = true;  mouseLeft = false;
            mouseUp = false;    mouseDown = false;
        }
        else
        {
            mouseLeft = false;  mouseRight = false;
            if(mousePosY < (screenY / 2))
            {
                mouseUp = true; mouseDown = false;
            }
            else
            {
                mouseDown = true;   mouseUp = false;
            }
        }
    }

    void Animations()
    {
        if(mouseLeft || mouseRight)
        {
            if (isIdle)
                playerAnim.Play("PlayerIdleSide");
            else
                playerAnim.Play("PlayerWalkSide");
        }
        else if (mouseUp)
        {
            if (isIdle)
                playerAnim.Play("PlayerIdleUp");
            else
                playerAnim.Play("PlayerWalkUp");
        }
        else
        {
            if (isIdle)
                playerAnim.Play("PlayerIdleDown");
            else
                playerAnim.Play("PlayerWalkDown");
        }
    }
}