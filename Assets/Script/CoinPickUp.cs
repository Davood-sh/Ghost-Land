using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public AudioSource coinSound;
    public AudioClip clip;
    // Start is called before the first frame update
    public int pointToAdd;
    void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerMovement>() == null)
        return;
        ScoreManager.AddPoints(pointToAdd);
        coinSound.PlayOneShot(clip);
        Destroy(gameObject);

    }
}
