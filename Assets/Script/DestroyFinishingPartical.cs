using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishingPartical : MonoBehaviour
{
    ParticleSystem thisParticle;
    // Start is called before the first frame update
    void Start()
    {
        thisParticle = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(thisParticle.isPlaying)
        return;
        Destroy(gameObject);
        
    }
}
