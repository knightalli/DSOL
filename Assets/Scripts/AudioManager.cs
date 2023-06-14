using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource SFX;

    public AudioClip back;
    public AudioClip jump;
    public AudioClip shortShoot;
    public AudioClip longShoot;

    private void Start()
    {
        music.clip = back; 
        music.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}


