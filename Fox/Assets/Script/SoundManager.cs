using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    [SerializeField]
    private AudioClip collectionGet, playerDie, enemyDie;

    private void Awake()
    {
        instance = this;
    }

    public void CollectionAudio()
    {
        audioSource.clip = collectionGet;
        audioSource.Play();
    }

    public void PlayerDieAudio()
    {
        audioSource.clip = playerDie;
        audioSource.Play();
    }

    public void EnemyDieAudio()
    {
        audioSource.clip = enemyDie;
        audioSource.Play();
    }
}
