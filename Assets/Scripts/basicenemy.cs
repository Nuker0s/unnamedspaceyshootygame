using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class basicenemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public Vector3 targetpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position != targetpos) 
        {
            targetpos = target.position;
            agent.SetDestination(targetpos);
            

        }
        
    }
    private void OnDrawGizmos()
    {
        foreach (var item in agent.path.corners)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(item, 1f);
        }
    }
}
