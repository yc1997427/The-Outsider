using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectAshes : MonoBehaviour
{
    public AudioClip leavingTrack;
    private AudioManager theAM;
    public Text objective;
    public Text story;
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
            objective.text = "Objective: Burry mother's ashes in the temple.";
            story.text = "They slaughtered mother, worshiping her burnings as holy ashes!";
            Debug.Log("Ashes collected.");
            if (leavingTrack != null)
            {
                theAM.ChangeSong(leavingTrack);
            }
        }
    }
}
