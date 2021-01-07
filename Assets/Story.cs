using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Story : MonoBehaviour
{
    public Text story;
    public Text objective;
    public GameObject cubes;
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
        objective.text = "Objective: Find the Emporer's house.";
        story.text = "      I must find mother's ashes.\nThe Emporer took hold of them when I was exiled.";
        cubes.SetActive(false);
    }
}
