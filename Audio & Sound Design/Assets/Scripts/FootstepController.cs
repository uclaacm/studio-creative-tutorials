using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public CheckTerrain checkTerrain;
    public AudioSource source;
    public AudioClip[] dirtClips;
    public AudioClip[] grassClips;

    AudioClip previousClip;

    void Start() {
        checkTerrain = GetComponent<CheckTerrain>();
        source = GetComponent<AudioSource>();
    }



    public void PlayFootstep()
    {   
        checkTerrain.UpdatePosition();

        if (checkTerrain.cellMix[0] > 0)
        {
            source.PlayOneShot(GetClip(grassClips), checkTerrain.cellMix[0]);
        }

        if (checkTerrain.cellMix[1] > 0)
        {
            source.PlayOneShot(GetClip(dirtClips), checkTerrain.cellMix[1]);
        }
    }

    AudioClip GetClip(AudioClip[] clipArray)
    {
        int attempts = 3;
        AudioClip selectedClip = 
        clipArray[Random.Range(0, clipArray.Length - 1)];

        while (selectedClip == previousClip && attempts > 0)
        {
            selectedClip = 
            clipArray[Random.Range(0, clipArray.Length - 1)];
            
            attempts--;
        }

        previousClip = selectedClip;
        return selectedClip;
    }
}
