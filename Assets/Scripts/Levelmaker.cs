using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemySpawner;

public class Levelmaker : MonoBehaviour
{
    public List<PrefabSpawnData> Spawners = new List<PrefabSpawnData>();
    public float wordsize;
    public Transform todestroy;
    public Transform moneyparent;
    public asteroidscatter asteroids;
    public bool regenerateALL = true;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (regenerateALL) 
        {

        }
        if (regenerateALL)
        {
            regenerateALL = false;
            AllGen();
        }
    }
    public void AllGen() 
    {
        player.position = Vector3.zero;
        foreach (Transform item in todestroy)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in moneyparent)
        {
            Destroy(item.gameObject);
        }
        asteroids.regen();
        StartCoroutine(Spawner.Spawn(Vector3.zero, wordsize, Spawners, todestroy, 1));
    }
}
