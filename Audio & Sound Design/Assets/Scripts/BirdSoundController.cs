using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script adapted from https://johnleonardfrench.com/unity-audio-tutorial-series-adding-sounds-to-the-sun-temple/
public class BirdSoundController : MonoBehaviour
{
    public AudioSource birdAudioSource;

    [SerializeField] private float fadeTime = 5;
    
    [SerializeField] private float minTimeOff=5;
    [SerializeField] private float maxTimeOff=25;
    private float timeOff;

    [SerializeField] private float minTimeOn=5;
    [SerializeField] private float maxTimeOn=25;

    private float timeOn;

    public float minVol=0.5f;
    public float maxVol=1;
    private float birdsVol;
    public float timer;
    public float timeUntilNextEvent;

    bool birdsPlaying;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeValues();
        timeUntilNextEvent = timeOff;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeUntilNextEvent)
        {
            if (birdsPlaying)
            {
                StartCoroutine(FadeBirds(birdsVol, 0, fadeTime));
                birdsPlaying=false;
                RandomizeValues();
                timeUntilNextEvent = timeOn + fadeTime;
            }
            else
            {
                StartCoroutine(FadeBirds(0, birdsVol, fadeTime));
                birdsPlaying=true;
                RandomizeValues();
                timeUntilNextEvent = timeOn + fadeTime;
            }
            
            timer = 0f;
        }
    }

    void RandomizeValues()
    {
        timeOff = Random.Range(minTimeOff, maxTimeOff);
        timeOn = Random.Range(minTimeOn, maxTimeOn);
        birdsVol = Random.Range(minVol, maxVol);
    }

    IEnumerator FadeBirds(float startValue, float endValue, float duration)
    {
        float currentTime = 0;

        while (currentTime <= duration) {
            birdAudioSource.volume = Mathf.Lerp(startValue, endValue, (currentTime / duration));
            currentTime += Time.deltaTime;
        }

        yield return null;
    }
}
