using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Spawner : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

        spawnpoints = new GameObject[5];
        
        for(int i=0; i<spawnpoints.Length; i++)
        {
            spawnpoints[i] = transform.GetChild(i).gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            int id = Random.Range(0, spawnpoints.Length);
            Instantiate(enemy, spawnpoints[id].transform.position, spawnpoints[id].transform.rotation);
        }
    }
}
