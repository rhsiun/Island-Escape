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
    public int blood = 100;

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
            print("within attack range for the enemy");
            target.GetComponent<PlayerController>().blood -= 1;
            print("the character is being attacked by the enemy");
            print(target.GetComponent<PlayerController>().blood);
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
            // print("Distance: " + distance);

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

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Bullet>())
        {
            Destroy(other.gameObject);
            blood -= 10;
            print("Enemy is attacked");
            print("currentblood: "+blood);
        }
        if(blood<0)
        {
            Destroy(gameObject);
        }
    }
}
