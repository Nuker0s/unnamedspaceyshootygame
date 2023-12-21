using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIMarkers : MonoBehaviour
{
    public Transform target;
    public Transform player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && player != null) 
        {
            transform.position = player.position + (target.position - player.position).normalized * 10;
            transform.rotation = Quaternion.LookRotation((target.position - player.position).normalized);
        }
        else
        {
            target = transform.parent;
            player = Fighter.player.transform;
        }

    }
}
