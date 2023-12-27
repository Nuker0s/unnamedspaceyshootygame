using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public float hp = 100;
    public bool cancollectmoney;
    public int money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (cancollectmoney)
        {
            moneychunk chunk = other.gameObject.GetComponent<moneychunk>();
            if (chunk != null)
            {
                
                money += chunk.value;
                Destroy(chunk.gameObject);

            }

        }
    }

    public virtual void ReciveDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }
    public virtual void Death() 
    {
        Destroy(gameObject);
        Debug.Log("yep");
    }

}
