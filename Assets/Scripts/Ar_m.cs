using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ar_m : EnemyHP
{
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        HP = 15;
        damage = 15;
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -speed * Time.deltaTime));
    }
}
