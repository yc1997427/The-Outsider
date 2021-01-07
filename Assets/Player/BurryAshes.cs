using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BurryAshes : MonoBehaviour
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
        Debug.Log("Press E to burry ashes.");
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            story.text = "      Ashes burried.\n    Time for the last judgement.";
            objective.text = "The last judgement.\nForgive humans or kill them?";
            Debug.Log("THE END!");
            Application.Quit();
        }
    }
}
