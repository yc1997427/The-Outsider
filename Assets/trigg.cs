using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class trigg : MonoBehaviour
{
    public Text story;
    public Text objective;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        objective.text = "Objective: Enter the Emporer's house.";
        story.text = "      This looks like the Emporer's house.\n      I hope there's nobody inside.";
    }
}
