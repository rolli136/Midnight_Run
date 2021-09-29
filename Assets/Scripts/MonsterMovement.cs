using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{

    public Transform target;
    public NavMeshAgent agent;
    //public float lookRadius = 100f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        //cam = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
       float distance = Vector3.Distance(target.position, transform.position);
       agent.SetDestination(target.position);
       if(distance <= agent.stoppingDistance)
       {
           FaceTarget();
       }
       
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
