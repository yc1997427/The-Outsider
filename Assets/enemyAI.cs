using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    int MoveSpeed=4;
    int MaxDist=10;
    int MinDist=5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if(Vector3.Distance(transform.position, Player.position)>MinDist){
        	transform.position+=transform.forward*MoveSpeed*Time.deltaTime;


        	if(Vector3.Distance(transform.position, Player.position)<MaxDist){
        		
        	}
        }
    }
}
