using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public int gold;    // the amount of gold in the chest
    bool opened;        // whether or not the chest has been opened

    public GameManager gameManager;     // the game manager
    
    // Start is called before the first frame update
    // void Start(){}

    // Update is called once per frame
    // void Update(){}

    // OnTriggerEnter2D is called when another object enters a trigger attached to this object
    void OnTriggerEnter2D(Collider2D obj)
    {
        // if the player touches the chest and the chest is not open yet...
        if(obj.gameObject.tag == "Player" && opened == false)
        {
            opened = true;      // open the chest
            gameManager.CountTreasure(gold);        // update the treasure
            this.gameObject.SetActive(false);       // set the chest to be inactive
        }
    }
}