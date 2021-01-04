using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{

    public AudioClip enteringTrack;
    private bool leaving=false;
    public AudioClip leavingTrack;
//    [Range(0, 100)]
//    public int volume;

    private AudioManager theAM;

    // Start is called before the first frame update
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"&&!leaving)
        {
            if (enteringTrack != null)
            {
                theAM.ChangeSong(enteringTrack);
                leaving=true;
            }
        }
        if (other.tag == "Player"&&!leaving){
            if (leavingTrack != null)
            {
                theAM.ChangeSong(leavingTrack);
                leaving=false;
            }
        }
    }

}
