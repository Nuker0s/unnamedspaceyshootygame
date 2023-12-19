using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float damage;
    public float playerdetecionrange = 60;
    public float attackrange;
    public float attackcooldown;
    public bool attacking;
    public Transform target;
    public NavMeshAgent agent;
    public Vector3 targetpos;
    private bool scatter = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        target = GameObject.Find("Bob").transform;
    }

    // Update is called once per frame
    public virtual void Update()
    {

        navigation();
    }
    public virtual void navigation() 
    {
        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) < playerdetecionrange)
            {
                if (Vector3.Distance(target.position, transform.position) < attackrange)
                {
                    agent.isStopped = true;
                    StartCoroutine(attack());
                }
                else
                {
                    agent.isStopped = false;
                    StopCoroutine(attack());
                    if (target.position != targetpos)
                    {
                        targetpos = target.position;
                        agent.SetDestination(targetpos);


                    }
                }

            }
        }
        else 
        {
            if (!scatter)
            {
                scatter = true;
                agent.isStopped = false;
                agent.SetDestination(new Vector3(transform.position.x + Random.Range(-150, 150), 0, transform.position.y + Random.Range(-150, 150)));
            }

        }

    }
    public virtual IEnumerator attack()
    {
        yield return null;
    }
}
