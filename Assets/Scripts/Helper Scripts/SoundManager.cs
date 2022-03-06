using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip jumpClip, gameOverClip;

    // get component is not used because there are two audio sources.. one for music and the other for the other audio?
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void jumpSoundFX()
    {
        soundFX.clip = jumpClip;
        soundFX.Play();
    }

    public void gameOverSoundFX()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }





} //class
