﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PeasantAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private Animator animator;
    //int MoveSpeed = 4;
    //int MaxDist = 10;
    //int MinDist = 5;
    bool isAware = false;

    int viewDistance = 35;

    //int voiceDistance = 0;
    int fov = 360;
    int chaseSpeed = 9;
    int wanderSpeed = 3;

    int SecondSearchDistance=70;

    int numOfAwaredHumans;

    int attackRange = 5;

    bool chase=false;

    //bool nowMovingToTarget = false;
    float dist;

    public float wanderRadius=100.0f;


    public Text AwaredCountText;

    public GameObject controller;

    public GameObject deathSplash;

    Animator otherAnimator;

    bool punched =false;
    Vector3 target;

    private UnityEngine.AI.NavMeshAgent agent;


    void Start()
    {   
        controller=GameObject.FindWithTag("GameController");
        numOfAwaredHumans=controller.GetComponent<GameController>().Awared();
        player=GameObject.FindWithTag("Player").transform;
        otherAnimator=GameObject.FindWithTag("Player").GetComponent<Animator> ();
        animator = gameObject.GetComponent<Animator>();

        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        AwaredCountText=GameObject.Find("Awaredhumans").GetComponent<Text>();

        target=new Vector3(499,0,650);
        
        //numOfAwaredHumans=Convert.ToInt32(AwaredCountText.text.Trim().Split(':')[1]);


    }

    // Update is called once per frame
    void Update()
    {   
        if(controller.GetComponent<GameController>().playerDeath()){
            animator.SetBool("isPlayerDied", true);
        }
        numOfAwaredHumans=controller.GetComponent<GameController>().Awared();
        //the enemy detects the player
        //if he sees the player, he will chase up
        
        dist=Vector3.Distance(transform.position, target);;

        //if enemy see player;

        if (isAware)
        {   
            if(numOfAwaredHumans<10||!chase){

                //if less than 10 of enemies awared player, they will run away from the player towards the temple 
                //OnAttack();

                agent.SetDestination(target);
                
                
                if ( dist<15){
                    animator.SetBool("isRunning", true);
                    agent.speed = wanderSpeed;
                    chase=true;
                    
                }
                else{
                    animator.SetBool("isRunning", true);
                    agent.speed = chaseSpeed;
                   
                }
            }
            else{
    
                //Debug.Log(controller.GetComponent<GameController>().secondAware());

                // if more than 9 enemies have awared player, they will chase up player altogether and attack 
                if(chase&&controller.GetComponent<GameController>().secondAware()){

                    if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
                    {            
                    //if player is within the attack range of enemies, they will attack with wander speed 
                        agent.speed = wanderSpeed;
                        OnAttack();
                    }
    
                    //if player is outside of enemy attack range, they will chase up player
                    animator.SetBool("isRunning", true);
                    agent.SetDestination(player.transform.position);
                    agent.speed=chaseSpeed;
                    //animator.SetBool("attack", false);

                }
                else{
                    SecondSearchForPlayer();
                }

            }
            gotAttacked();
        }
        //if not, he will keep wandering around
        else
        {
            //if the enemies is not aware of the player, they will wander around 
            Vector3 newPos=RandomNavSphere(transform.position, wanderRadius,-1);
            agent.SetDestination(newPos);
            animator.SetBool("isRunning", true);
            agent.speed = wanderSpeed;

            SearchForPlayer();

            
        }
    }

    /*private void OnCollisionEnter(Collision other){
        //detecting player collision 
        
        if(other.gameObject.tag =="Player"){
            int punchId = Animator.StringToHash("Punch");
            AnimatorStateInfo animStateInfo = otherAnimator.GetCurrentAnimatorStateInfo(0);
            if ((Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(player.transform.position)) < fov / 2f)&&(Input.GetKeyDown("j"))){
                Instantiate(deathSplash,transform.position,Quaternion.identity);
                GameObject.Destroy(gameObject);
            }
            if ((Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(player.transform.position)) < fov / 2f)&&(Input.GetKeyDown("k"))){
                Instantiate(deathSplash,transform.position,Quaternion.identity);
                GameObject.Destroy(gameObject);
            }
                
            
        }

    }*/

    public void gotAttacked(){

        RaycastHit hit;

        if ((Input.GetKeyDown("j"))&&Vector3.Distance(player.transform.position, transform.position) < 4){
            if(Physics.Linecast(player.transform.position, transform.position, out hit, -1)){

                if (hit.transform.CompareTag("Enemy")){
                    if(punched){
                        Instantiate(deathSplash,transform.position,Quaternion.identity);
                        GameObject.Destroy(gameObject);
                        punched=true;
                    }
                }
                punched=true;  
            }
        }
        if ((Input.GetKeyDown("k"))&&Vector3.Distance(player.transform.position, transform.position) < 4){
            if(Physics.Linecast(player.transform.position, transform.position, out hit, -1)){

                if (hit.transform.CompareTag("Enemy")){
                    
                    Instantiate(deathSplash,transform.position,Quaternion.identity);
                    GameObject.Destroy(gameObject);        
                    
                }
            
            }
        }

    }

    //detecting player if he is within the enemy viewdistance and foward sight.
    public void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(player.transform.position)) < fov / 2f)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, player.transform.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        /*if(isAware){
                            controller.GetComponent<GameController>().OnSecondAware();
                        }*/
                        OnAware();
                    }
                }

            }
        }

        /*else if (Vector3.Distance(player.transform.position, transform.position) < voiceDistance)
        {   

            OnAware();

        }*/
    }
    public void SecondSearchForPlayer(){
        if (Vector3.Distance(player.transform.position, transform.position) < SecondSearchDistance){
            controller.GetComponent<GameController>().OnSecondAware();
        }
    }

    //assign a random position or target for enemies wander around 
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermark){
        Vector3 randDirection=UnityEngine.Random.insideUnitSphere*dist;
        randDirection+=origin;
        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randDirection,out navHit,dist,layermark);

        return navHit.position;
    }

    // enemies aware player
    public void OnAware()
    {
        isAware = true;
  

        controller.GetComponent<GameController>().detected();

    }

    //set up the UI display text
    /*public void SetAwaredCountText(){
        numOfAwaredHumans+=1;
        controller.GetComponent<GameController>().detected();
        //Debug.Log(numOfAwaredHumans);

    }*/


    // attack player 
    public void OnAttack()
    {
        animator.SetBool("isAttack", true);
        //Debug.Log("attack");
    }
}
