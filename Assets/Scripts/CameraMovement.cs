using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public GameObject playerChar;
    
    // Start is called before the first frame update
    void Start()
    {
        playerChar = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerChar.transform.position.x, playerChar.transform.position.y, -10);
    }
}