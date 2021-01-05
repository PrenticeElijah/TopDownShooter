using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    
    public bool hasEnemies;
    public List<Enemy> roomEnemies;
    public List<Vector3> startPos;
    public GameManager player;

    public CameraMovement cam;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {   
            cam.FindRoom(this.transform.position);
            if(hasEnemies)
                ActivateEnemy();
        }
    }

    void OnTriggerExit2D(Collider2D exited)
    {
        if(exited.gameObject.tag == "Player"
        && hasEnemies == true)
        {
            ResetEnemy();
        }
        else if(exited.gameObject.tag == "Bullet")
        {
            exited.gameObject.SetActive(false);
        }
    }

    void ActivateEnemy()
    {}

    void ResetEnemy()
    {}
}