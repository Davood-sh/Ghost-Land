using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
     
    public GameObject currentCheckPoint;
    private PlayerMovement player;
    public GameObject deathPartical;
    public GameObject respawnPartical;
    public int penaltyOfDeath;
    private CameraController cam;
    public PlayerHealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        
        player = FindObjectOfType<PlayerMovement>();
        cam = FindObjectOfType<CameraController>();
        healthManager = FindObjectOfType<PlayerHealthManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }
    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathPartical,player.transform.position,player.transform.rotation);
        cam.isFollowing = false;
        ScoreManager.AddPoints(-penaltyOfDeath);
        yield return new WaitForSeconds(0.5f);
        player.transform.position = currentCheckPoint.transform.position;
        Instantiate(respawnPartical,player.transform.position,player.transform.rotation);
        cam.isFollowing = true;
        healthManager.FullHealth();
        healthManager.isDead = false;

    }
    
    


}
