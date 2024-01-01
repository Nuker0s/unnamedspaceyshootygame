using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class balance : MonoBehaviour
{
    public Text text;
    public Damagable player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            text.text = player.money.ToString();
        }
    }
}
