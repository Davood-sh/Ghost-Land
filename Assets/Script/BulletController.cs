using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public PlayerMovement player;
    public GameObject enemyParticle;
    public int pointToKill;
    public int damageToGive;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if(player.transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
           // Destroy(other.gameObject);
           // Instantiate(enemyParticle,other.transform.position,other.transform.rotation);
           // ScoreManager.AddPoints(pointToKill);
           other.GetComponent<EnemyHealth>().GiveDamage(damageToGive);
        }        
        Destroy(gameObject);
    }
}
