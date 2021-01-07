using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class promptOpenDoor : MonoBehaviour
{
    public Text prompt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        prompt.text = "Press 'E' to open door.";
    }

    private void OnCollisionExit(Collision collision)
    {
        prompt.text = "";
    }
}
