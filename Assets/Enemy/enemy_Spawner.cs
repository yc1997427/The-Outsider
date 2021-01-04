using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_Spawner : MonoBehaviour
{
    public List<PeasantAI> enemies;
    public PeasantAI enemy;

    [Range(0,100)]
    public int numberOfEnemies=30;
    private float range=25.0f;

    // Start is called before the first frame update
    void Start()
    {

        enemies = new List<PeasantAI>(); // init as type
        for (int index = 0; index < numberOfEnemies; index++)
        {
            PeasantAI spawned = Instantiate(enemy, RandomNavmeshLocation(range), Quaternion.identity) as PeasantAI;
            enemies.Add(spawned);
        }
        
    }

    public Vector3 RandomNavmeshLocation(float radius){
        Vector3 randomDirection= Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}