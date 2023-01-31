using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    bool playerInZone;
    public string levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        playerInZone = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && playerInZone)
        {
            SceneManager.LoadScene(levelLoader);
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerInZone = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerInZone = false;
        }
    }
}
