using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerHealthManager : MonoBehaviour
{
    PlayfabManager playfabManager;
    public int maxPlayerHealth;
    public static int playerHealth;
    Text text;
    LevelManager levelManager;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        playfabManager = GetComponent<PlayfabManager>();
        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
        isDead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerHealth <= 0)
        {

            SceneManager.LoadScene(7);
            playfabManager.SendLeaderBoard(PlayerPrefs.GetInt("HighScore",ScoreManager.score));

            // playerHealth = 0;
            // levelManager.RespawnPlayer();
            // isDead = true;
        }
        text.text = "" + playerHealth;        
    }
    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
    }
    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
