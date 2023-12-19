using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidscatter : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject oldparent;
    public Vector2 minmaxastsize;
    public float range = 100;
    public float astcount;
    public bool regenerate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (regenerate) 
        {
            regenerate = false;
            try
            {
                Destroy(oldparent);
            }
            catch (System.Exception)
            {

                throw;
            }
            GameObject p = new GameObject();
            oldparent = p;
            for (int i = 0; i < astcount; i++)
            {

                Vector3 pos = new Vector3(Random.Range(0, range), Random.Range(0, 0), Random.Range(0, range));
                pos -= new Vector3(range / 2, 0, range / 2);
                Vector3 rot = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
                GameObject ast = Instantiate(asteroid, pos, Quaternion.Euler(rot), p.transform);
                float size = Random.Range(minmaxastsize.x, minmaxastsize.y);
                ast.transform.localScale = new Vector3 (size, size, size);
            }

        }
    }
}
