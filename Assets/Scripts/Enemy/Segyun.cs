using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segyun : EnemyHP
{

    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        damage = 20;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -speed * Time.deltaTime));
    }
}
