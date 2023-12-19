using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class basicenemy : Enemy
{
    public float chompcasttime;
    public float chomprange;
    
    private void OnDrawGizmos()
    {
        foreach (var item in agent.path.corners)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(item, 1f);
        }
    }
    public override IEnumerator attack()
    {
        if (attacking)
        {

        }
        else
        {
            attacking = true;
            Debug.Log("attackstarted");
            yield return new WaitForSeconds(chompcasttime);
            if (target != null)
            {
                if (Vector3.Distance(target.position, transform.position) < chomprange)
                {

                    Debug.Log("chomped");
                    Damagable todamage = target.gameObject.GetComponent<Damagable>();
                    if (todamage != null)
                    {
                        todamage.ReciveDamage(damage);

                    }


                }
            }
            else
            {
                Debug.Log("miss");
            }
            yield return new WaitForSeconds(attackcooldown);
            attacking = false;
        }

    }
}
