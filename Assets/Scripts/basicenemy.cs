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
        yield return new WaitForSeconds(chompcasttime);
    }
}
