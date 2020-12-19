﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int fov = 180;
    int chaseSpeed = 50;
    int wanderSpeed = 20;

    int numOfAwaredHumans = 10;

    int attackRange = 0;

    private UnityEngine.AI.NavMeshAgent agent;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //the enemy detects the player
        //if he sees the player, he will chase up
        if (isAware)
        {
            agent.SetDestination(player.transform.position);
            animator.SetBool("isRunning", true);
            agent.speed = chaseSpeed;

            Debug.Log("Chasing player");
            if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
            {
                agent.speed = wanderSpeed;
                OnAttack();
            }
        }
        //if not, he will keep wandering around
        else
        {
            animator.SetBool("isRunning", false);
            SearchForPlayer();

            agent.speed = wanderSpeed;
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
        if (Vector3.Distance(player.transform.position, transform.position) < voiceDistance)
        {
            OnAware();
        }
    }
    public void OnAware()
    {
        isAware = true;

    }

    public void OnAttack()
    {

    }
}
