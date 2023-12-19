using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mosuepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position =new Vector3(mosuepos.x,0,mosuepos.z);
        
    }

}
