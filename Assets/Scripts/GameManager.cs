using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;           // the player object
    public Text healthCount;        // displays the player's health in the UI
    public Text treasureCount;      // displays how much gold the player has
    public int playerTreasure;      // the amount of gold the player possesses
    
    // Start is called before the first frame update
    // void Start(){}

    // Update is called once per frame
    // void Update(){}

    // CountHealth updates the UI to display the player's current health
    public void CountHealth()
    {
        healthCount.text = "x " + player.health.ToString();     // convert the player's health to a string an update the health Text element
    }

    // CountTreasure updates the UI to display the player's current gold
    public void CountTreasure(int change)
    {
        playerTreasure += change;       // update the amount of gold the player has
        treasureCount.text = playerTreasure.ToString();     // convert the player's gold to a string an update the gold Text element
    }
}