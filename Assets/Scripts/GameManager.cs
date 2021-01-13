using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;           // the player object
    public Text healthCount;        // displays the player's health in the UI
    public Text treasureCount;      // displays how much gold the player has
    public int playerTreasure;      // the amount of gold the player possesses
    
    public ObjectPooling explosionPool;     // the pool from which to explosion animations from

    public GameObject DeathScreen;          // the screen to display when the player dies

    public GameObject musicMng;         // the game's music manager
    public GameObject sfxMng;           // the game's sound effects manager

    AudioSource musicPlayer;            // the music manager's audio source component
    AudioSource sfxPlayer;              // the sfx manager's audio source component

    public List<AudioClip> sfx;         // the list of available sfx

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = musicMng.GetComponent<AudioSource>();     // get the audio sourc components from the musc and sfx managers
        sfxPlayer = sfxMng.GetComponent<AudioSource>();

        musicPlayer.Play(0);    // play the game music
    }

    // Update is called once per frame
    // void Update(){}

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        // the player is dead if their health is less than or equal to 0
        if(player.health <= 0 && player.gameObject.activeSelf == true)
            PlayerDeath();
    }

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

    // CharacterDeath plays the death sound effect and plays the death animation at the dead character's position
    public void CharacterDeath(Vector3 deadChar)
    {
        PlaySFX(0);             // call PlaySFX to play the death sound effect
        GameObject explosion = explosionPool.GetPooledObject();     // return a death animation from the explosion pool
        if(explosion != null)
        {
            explosion.transform.position = deadChar + new Vector3(0,0.5f,0);    // place the animation where the character died
            explosion.SetActive(true);                                          // set the death animation to active
            explosion.GetComponent<Explosion>().Explode();                      // call Explode function to play the animation and set it inactive after playing
        }
    }

    // PlaySFX plays a sound effect from the sfx list based on the int passed
    public void PlaySFX(int sfxCode)
    {
        sfxPlayer.clip = sfx[sfxCode];      // load and play the sfx clip
        sfxPlayer.Play();
    }

    // PlayerDeath is used to handle the death screen and animation of the player's death
    public void PlayerDeath()
    {
        player.gameObject.SetActive(false);                     // set the player to inactive
        CharacterDeath(player.gameObject.transform.position);   // call CharacterDeath with the player's position
        DeathScreen.SetActive(true);                            // show the DeathScreen
        musicPlayer.Pause();                                    // pause the music
    }

    // Reset reloads the scene
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // EndGame closes the game window
    public void EndGame()
    {
        Application.Quit();
    }
}