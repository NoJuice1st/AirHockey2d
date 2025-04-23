using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffects : MonoBehaviour
{
    private ParticleSystem pS;
    private float waitTime = 0.5f;
    private AudioSource AS;

    void Start() 
    {
        pS = GetComponent<ParticleSystem>();
        AS = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.name.Contains("Ball") && !pS.isPlaying)
        {
            pS.Play();
            AS.Play();
        }
    }

    /*void Update() {
        if (pS.isPlaying)
        {
            waitTime -= Time.deltaTime;
            if (waitTime < 0)
            {
                pS.Stop();
                waitTime = 0.5f;
            }
        }
    }*/
}
