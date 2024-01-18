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
                    StartCoroutine(SpawnEnemies());
                }

            }
        }
    }
    public IEnumerator SpawnEnemies() 
    {
        foreach (PrefabSpawnData enemychunks in enemies)
        {
            for (int i = 0; i < enemychunks.howmuchtospawn; i++)
            {
                
                while (true)
                {
                    Debug.Log("spawnerrangecheck");
                    yield return new WaitForEndOfFrame();
                    Vector3 pos = transform.position + new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
                    
                    if (NavMesh.SamplePosition(pos, out NavMeshHit hit, 30, 1))
                    {
                        Instantiate(enemychunks.enemy, hit.position, Quaternion.identity, transform);
                        break;
                    }
                }
                
                
                
                
            }
        }
        yield return null;
    }

    [System.Serializable]
    public class PrefabSpawnData 
    {
        public GameObject enemy;
        public int howmuchtospawn;
    }
}
