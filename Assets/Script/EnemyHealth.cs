using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    public GameObject deathEffect;
    public int pointToDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect,transform.position,transform.rotation);
            ScoreManager.AddPoints(pointToDeath);
        }
    }
    public void GiveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
    }
}
