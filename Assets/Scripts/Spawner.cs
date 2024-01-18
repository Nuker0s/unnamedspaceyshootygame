using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static IEnumerator Spawn(Vector3 center,float range,List<PrefabSpawnData> tospawn, Transform parent,int navmeshlayer) 
    {
        foreach (PrefabSpawnData enemychunks in tospawn)
        {
            for (int i = 0; i < enemychunks.howmuchtospawn; i++)
            {

                while (true)
                {
                    Debug.Log("spawnerrangecheck");
                    yield return new WaitForEndOfFrame();
                    Vector3 pos = center + new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));

                    if (NavMesh.SamplePosition(pos, out NavMeshHit hit, 30, navmeshlayer))
                    {
                        Instantiate(enemychunks.enemy, hit.position, Quaternion.identity, parent);
                        break;
                    }
                }

            }
        }
        yield return null;

    }

}
[System.Serializable]
public class PrefabSpawnData
{
    public GameObject enemy;
    public int howmuchtospawn;
}