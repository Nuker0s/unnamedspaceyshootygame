using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public Transform player;
    public float lerp;
    public float attractdistance;
    public float collectdistance;

    public static MoneyManager instance;

    public static List<GameObject> moneyprefabs = new List<GameObject>();

    public float inbank;
    // Start is called before the first frame update
    void Start()
    {
        MoneyManager.instance = this;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        foreach (Transform moneygroup in transform)
        {
            if (moneygroup.childCount < 1)
            {
                Destroy(moneygroup.gameObject);
            }
            foreach (Transform money in moneygroup)
            {
                
                if (Vector3.Distance(player.position,money.position) < attractdistance)
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
