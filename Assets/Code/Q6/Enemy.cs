using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Outlets
    NavMeshAgent navAgent;

    //Configuration
    public Transform priorityTarget;
    public Transform target;
    public Transform patrolRoute;

    //State tracking
    public int patrolIndex;
    public float chaseDistance;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float priorityTargetDistance = Vector3.Distance(transform.position, priorityTarget.position);

        if(priorityTargetDistance <= chaseDistance) {
            target = priorityTarget;
            GetComponent<Renderer>().material.color = Color.red;
        } else {
            GetComponent<Renderer>().material.color = Color.white;
        }
        
        if(target) {
            navAgent.destination = target.position;
        }
        if(patrolRoute) {
            target = patrolRoute.GetChild(patrolIndex);

            float distance = Vector3.Distance(transform.position, target.position);
            print("Distance: " + distance);

            if(distance <= 1.5f) {
                patrolIndex++;
                if(patrolIndex >= patrolRoute.childCount) {
                    patrolIndex++;
                    if(patrolIndex >= patrolRoute.childCount) {
                        patrolIndex = 0;
                    }
                }
            }
        }
    }
}
