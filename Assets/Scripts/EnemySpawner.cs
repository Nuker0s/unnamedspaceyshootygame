using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public List<PrefabSpawnData> enemies = new List<PrefabSpawnData>();
    public float activationdistance;
    public float range;
    public bool turnedOn;
    public bool spawned;
    public NavMeshSurface surface; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!turnedOn)
        {
            if (Player.player != null)
            {
                
                if (Vector3.Distance(transform.position, Player.player.transform.position) < activationdistance)
                {
                    turnedOn = true;
                    StartCoroutine(Spawner.Spawn(transform.position,range,enemies,transform,1));
                }

            }
        }
        if (transform.childCount > 1)
        {
            spawned = true;
        }
        if (spawned)
        {
            if (transform.childCount == 1)
            {
                Player.playerscript.keys += 1;
                spawned = false;
            }
        }
    }



}
