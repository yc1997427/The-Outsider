using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurryAshes : MonoBehaviour
{
    public Canvas CanvasObject;
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
            CanvasObject.GetComponent<Canvas>().enabled = false;
            Debug.Log("THE END!");
        }
    }
}
