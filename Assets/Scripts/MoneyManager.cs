using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public Transform player;
    public float lerp;
    public float attractdistance;
    public float collectdistance;
    
    public static MoneyManager instance;
    [SerializeField]
    private List<GameObject> moneyprefabsinspector = new List<GameObject>();
    public static List<GameObject> moneyprefabs = new List<GameObject>();
    public float inbank;
    // Start is called before the first frame update
    void Start()
    {
        moneyprefabs = moneyprefabsinspector;
        MoneyManager.instance = this;
    }

    public static IEnumerator dropmoney(int money,Vector3 pos) 
    {
        Transform moneychunk = new GameObject($"moneychunk {money}").transform; 
        moneychunk.position = pos;
        moneychunk.parent = instance.transform;
        while (money > 0)
        {
            if (money >= 25)
            {
                money -= 25;
                Instantiate(moneyprefabs[2],pos,quaternion.identity).transform.parent = moneychunk;
            }
            if (money >= 5)
            {
                money -= 5;
                Instantiate(moneyprefabs[1], pos, quaternion.identity).transform.parent = moneychunk;
            }
            if (money >= 1)
            {
                money -= 1;
                Instantiate(moneyprefabs[0], pos, quaternion.identity).transform.parent = moneychunk;
            }

            yield return null;
        }

    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (player!=null)
        {
            foreach (Transform moneygroup in transform)
            {
                if (moneygroup.childCount < 1)
                {
                    Destroy(moneygroup.gameObject);
                }
                foreach (Transform money in moneygroup)
                {

                    if (Vector3.Distance(player.position, money.position) < attractdistance)
                    {
                        money.position = math.lerp(money.position, player.position, lerp);
                    }
                    if (Vector3.Distance(player.position, money.position) < collectdistance)
                    {
                        inbank += money.GetComponent<moneychunk>().value;
                        //Destroy(money.gameObject);

                    }
                }
            }
        }

    }
}
