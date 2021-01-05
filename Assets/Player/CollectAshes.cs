using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAshes : MonoBehaviour
{
    public AudioClip leavingTrack;
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
        Debug.Log("Press E to collect ashes.");
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            Debug.Log("Ashes collected.");
            if (leavingTrack != null)
            {
                theAM.ChangeSong(leavingTrack);
            }
        }
    }
}
