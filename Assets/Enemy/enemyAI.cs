/**

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private Animator animator;
    int MoveSpeed=4;
    int MaxDist=10;
    int MinDist=5;
    bool isAware=false;
    int viewDistance =20;

    int voiceDistance=10;
    int fov=180;
    int chaseSpeed=50;
    int wanderSpeed= 20;

    int numOfAwaredHumans=10;

    int attackRange=0;

    private UnityEngine.AI.NavMeshAgent agent;


    void Start()
    {
        animator=gameObject.GetComponent<Animator>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //the enemy detects the player
        //if he sees the player, he will chase up
        if(isAware){
            agent.SetDestination(player.transform.position);

            agent.speed=chaseSpeed;

            Debug.Log("Chasing player");
            if(Vector3.Distance(player.transform.position,transform.position)<attackRange){
                agent.speed=wanderSpeed;
                OnAttack();
            }
        }
        //if not, he will keep wandering around
        else{
            SearchForPlayer();

            agent.speed=wanderSpeed;
        }
    }

    //detecting player if he is within the enemy viewdistance and foward sight.
    public void SearchForPlayer(){
        if(Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(player.transform.position))<fov/2f){
            if(Vector3.Distance(player.transform.position,transform.position)<viewDistance){
                RaycastHit hit;
                if(Physics.Linecast(transform.position,player.transform.position, out hit, -1)){
                    if(hit.transform.CompareTag("Player")){
                        OnAware();
                    }
                }

            }
        }
        if(Vector3.Distance(player.transform.position,transform.position)<voiceDistance){
            OnAware();
        }
    }
    public void OnAware(){
        isAware=true;

    }

    public void OnAttack(){

    }
}

**/

//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;

    float distanceToPlayer = Mathf.Infinity;

    bool isProvked = false;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (isProvked)
        {
            EngagePlayer();
        }

        else if (distanceToPlayer <= chaseRange)
        {
            // if player is visible
            isProvked = true;
        }


    }

    // engage player if its within chase range and attack if its within stopping distance
    private void EngagePlayer()
    {
        FacePlayer();

        if (distanceToPlayer >= navMeshAgent.stoppingDistance)
        {
            ChasePlayer();
        }

        if (distanceToPlayer <= navMeshAgent.stoppingDistance)
        {
            AttackPlayer();
        }
    }

    private void ChasePlayer()
    {

      //  GetComponent<Animator>().SetBool("attack", false);
      //  GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
       // GetComponent<Animator>().SetBool("attack", true);
    }

    // to move enemy face 
    private void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }


    // display the chase range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }


}

