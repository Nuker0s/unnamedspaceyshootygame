using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemySpawner;

public class Levelmaker : MonoBehaviour
{
    public List<PrefabSpawnData> enemies = new List<PrefabSpawnData>();
    public Transform todestroy;
    public Transform moneyparent;
    public asteroidscatter asteroids;
    public bool regenerateALL = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (regenerateALL)
        {
            regenerateALL = false;
            AllGen();
        }
    }
    public void AllGen() 
    {
        foreach (Transform item in todestroy)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in moneyparent)
        {
            Destroy(item.gameObject);
        }
        asteroids.regen();
    }
}
