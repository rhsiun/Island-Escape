using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit : MonoBehaviour
{

    NavMeshAgent navAgent;
    public Transform target;
    public Transform patrolRoute;
    public int patrolIndex;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    public Vector3 RandomNavmeshLocation(float radius) {
         Vector3 randomDirection = Random.insideUnitSphere * radius;
         randomDirection += transform.position;
         NavMeshHit hit;
         Vector3 finalPosition = Vector3.zero;
         if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
             finalPosition = hit.position;            
         }
         return finalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(RandomNavmeshLocation(50f));

    }


    public void OnCollisionEnter(Collision other)
    {
        PlayerController targetPlayer = other.gameObject.GetComponent<PlayerController>();
        if (targetPlayer != null)
        {
            targetPlayer.rabbitNum+=1;
            Destroy(gameObject);
        }
    }

    

}
