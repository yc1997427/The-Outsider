using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSong : MonoBehaviour
{
    public AudioSource song;
    public GameObject AshesDoor;



    // Start is called before the first frame update
    void Start()
    {
        song = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == AshesDoor)
        {
            song.Play();
        }
    }

}
