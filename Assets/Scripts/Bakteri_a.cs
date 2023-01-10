using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakteri_a : EnemyHP
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        HP = 5;
        damage = 10;
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -speed * Time.deltaTime));
    }
}
