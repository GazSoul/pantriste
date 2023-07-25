using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioZombie : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float timeBetweenShots = 4f;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenShots)
        {
            audioSource.PlayOneShot(RandomClip());
            timer = 0;
        }
    }
    AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length-1)];
    }
}