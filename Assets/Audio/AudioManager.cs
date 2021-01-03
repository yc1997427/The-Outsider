using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSong(AudioClip music)
    {
        if (BGMusic.clip.name != music.name)
        {
            BGMusic.Stop();
            BGMusic.clip = music;
            BGMusic.Play();
        }
    }
}
