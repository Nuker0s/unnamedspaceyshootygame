using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdamagable : Damagable
{
    public Transform background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Death()
    {
        background.parent = null;
        base.Death();
        
    }

}
