using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerManager : MonoBehaviour
{
    public int damageToGive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            PlayerHealthManager.HurtPlayer(damageToGive);
            var player = other.GetComponent<PlayerMovement>();
            player.knockBackCount = player.knockBackLength;
            if(other.transform.position.x < transform.position.x)
            player.knockBackFromRight = true;
            else
            player.knockBackFromRight = false;
        }        
    }
}
