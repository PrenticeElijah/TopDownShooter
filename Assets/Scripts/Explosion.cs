using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator explodeAnimator;       // animator for the explosion
    
    // Start is called before the first frame update
    void Start()
    {
        explodeAnimator = GetComponent<Animator>();     // get the animator component
    }

    // Update is called once per frame
    // void Update(){}

    // Explode invokes Deactivate to play after the length of the animation
    public void Explode()
    {
        Invoke("Deactivate",0.417f);
    }

    // Deactivate sets the death animation to inactive
    void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}