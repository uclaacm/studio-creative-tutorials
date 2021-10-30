using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSoundController : MonoBehaviour
{
    // Randomize the start time for when each rune sound effect plays so there is no chorus
    private AudioSource audioSource;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.time = Random.Range(0, audioSource.clip.length);
    }
}
