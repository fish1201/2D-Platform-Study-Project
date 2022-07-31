using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator animator;
    //protected AudioSource deathAudio;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        //deathAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void JumpOn()
    {
        gameObject.tag = "Untagged";
        animator.SetTrigger("death");
        //deathAudio.Play();
        SoundManager.instance.EnemyDieAudio();
    }
}
