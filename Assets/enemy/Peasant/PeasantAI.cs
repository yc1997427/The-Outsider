using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PeasantAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private Animator animator;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;
    bool isAware = false;
    int viewDistance = 20;

    int voiceDistance = 10;
    int fov = 360;
    int chaseSpeed = 15;
    int wanderSpeed = 15;

    int numOfAwaredHumans;

    int attackRange = 0;

    bool nowMovingToTarget = false;
    float dist;

    public float wanderRadius=30.0f;


    public Text AwaredCountText;

    public GameObject controller;

    public GameObject deathSplash;



    private UnityEngine.AI.NavMeshAgent agent;


    void Start()
    {   
        controller=GameObject.FindWithTag("GameController");
        numOfAwaredHumans=controller.GetComponent<GameController>().Awared();
        player=GameObject.FindWithTag("Player").transform;
        animator = gameObject.GetComponent<Animator>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        AwaredCountText=GameObject.Find("Awaredhumans").GetComponent<Text>();
        
        numOfAwaredHumans=Convert.ToInt32(AwaredCountText.text.Trim().Split(':')[1]);


    }

    // Update is called once per frame
    void Update()
    {

        //the enemy detects the player
        //if he sees the player, he will chase up
        dist=agent.remainingDistance;


        if (isAware)
        {   
            if(numOfAwaredHumans<1){

                agent.SetDestination(new Vector3(499,0,784));

                
                if ( agent.remainingDistance==0){
                    animator.SetBool("isRunning", false);
                    agent.speed = 0;
                }
                else{
                    animator.SetBool("isRunning", true);
                    agent.speed = chaseSpeed;
                }
            }
            else{
                if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
                {            
                    agent.speed = wanderSpeed;
                    //OnAttack();
                }
                else{

                    animator.SetBool("isRunning", true);
                    agent.SetDestination(player.transform.position);
                    agent.speed=chaseSpeed;
                }
            }
        }
        //if not, he will keep wandering around
        else
        {
            Vector3 newPos=RandomNavSphere(transform.position, wanderRadius,-1);
            agent.SetDestination(newPos);
            animator.SetBool("isRunning", true);
            agent.speed = wanderSpeed;

            SearchForPlayer();

            
        }
    }

    private void OnTriggerEnter(Collider other){
   ;
        if(other.CompareTag("Player")){
          
            Instantiate(deathSplash,transform.position,Quaternion.identity);
            GameObject.Destroy(gameObject);
            
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
                        OnAware();
                    }
                }

            }
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < voiceDistance)
        {
            OnAware();
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermark){
        Vector3 randDirection=UnityEngine.Random.insideUnitSphere*dist;
        randDirection+=origin;
        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randDirection,out navHit,dist,layermark);

        return navHit.position;
    }

    public void OnAware()
    {
        isAware = true;
  
        SetAwaredCountText();

    }

    public void SetAwaredCountText(){
        numOfAwaredHumans+=1;
        controller.GetComponent<GameController>().detected();
        Debug.Log(numOfAwaredHumans);
        AwaredCountText.text=numOfAwaredHumans.ToString();
    }


    public void OnAttack()
    {

    }
}
