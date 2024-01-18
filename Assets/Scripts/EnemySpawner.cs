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
            if (Fighter.player != null)
            {
                
                if (Vector3.Distance(transform.position, Fighter.player.transform.position) < activationdistance)
                {
                    turnedOn = true;
                    StartCoroutine(Spawner.Spawn(transform.position,range,enemies,transform,1));
                }

            }
        }
    }



}
