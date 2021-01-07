using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeStory : MonoBehaviour
{
    public Text objective;
    // Start is called before the first frame update
    void Start()
    {
        objective = FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        objective.text = "Objective: Find the Emporer's house.";
    }
}
