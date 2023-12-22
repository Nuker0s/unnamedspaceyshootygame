using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Weapon : MonoBehaviour
{
    public SpriteRenderer sr;
    public BoxCollider bc;
    public Rigidbody rb;
    public GameObject bullet;
    public float damage;
    public float cooldown;
    public bool firing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void Fire() 
    {

    }
    public virtual void StopFire() 
    {

    }
    public virtual void Equip(Transform equipor) 
    {
        sr.enabled = false;
        rb.isKinematic = true;
        bc.enabled = false;

        transform.position = equipor.position;
        transform.rotation = equipor.rotation;

    }
    public virtual void UnEquip()
    {
        transform.eulerAngles = Vector3.zero;
        sr.enabled = true;
        bc.enabled = true;
        rb.isKinematic = false;
    }
}
