using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    [SerializeField] float pickupDist = 5f;
    Camera mainCam;
    public Text pickupText;
    public LayerMask layer;


    //public float healthPack = 50f;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, pickupDist, layer))
        {
            pickupText.enabled = true;
            pickupText.text = hit.transform.name.ToString();

            if (hit.transform.tag == "HealthPacks")
            {
                if (playerhealth.singleton.curhealth < playerhealth.singleton.maxhealth)
                {
                    Debug.Log("Picking Up");
                    PickUpHealth();
                }

                else
                {

                    pickupText.text = "Health Full";
                }
            }
        }

        else
        {
            pickupText.enabled = false;
        }
    }

    void PickUpHealth()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            HealthPack packScript = hit.transform.GetComponent<HealthPack>();
            float health = packScript.healthAmount;
            if (playerhealth.singleton.curhealth + health > playerhealth.singleton.maxhealth)
            {
                playerhealth.singleton.curhealth = playerhealth.singleton.maxhealth;
            }
            else
            {
                playerhealth.singleton.AddHealth(health);
            }
            Destroy(hit.transform.gameObject);
            pickupText.enabled = false;
        }
    }
}
