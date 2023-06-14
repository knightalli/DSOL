using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource musicScr;
    
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        musicScr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        musicScr.volume = musicVolume;
        
    }

    public void SetMusicVolume(float vol)
    {
        musicVolume = vol;
    }
}
