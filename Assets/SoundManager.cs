using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{


    public AudioSource jumpEfx;
    public AudioSource birdEfx;

    public AudioSource waterEfx;


    public static SoundManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
    }


    public void playBirdEfx(AudioClip clip)
    {
        birdEfx.clip = clip;
        birdEfx.Play();
    }
    public void playJumpEfx(AudioClip clip)
    {
        jumpEfx.clip = clip;
        jumpEfx.Play();
    }
    public void playWaterEfx(AudioClip clip)
    {
        waterEfx.clip = clip;
        waterEfx.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
