using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakteri_a : EnemyHP
{
    public float speed = 2f;
    public float speed2 = 0.1f;
    public int LR = 1;
    // Start is called before the first frame update
    void Start()
    {
        HP = 5;
        damage = 10;
    }

    // Update is called once per fram
    void Update()
    {
        transform.Translate(new Vector2(LR * speed2 * Time.deltaTime, -speed * Time.deltaTime));
    }

    public void OnCollisionEnter2D(Collision2D ooo)
    {
        if (ooo.gameObject.tag == "wall" || ooo.gameObject.tag == "enemy") LR *= -1;
        if (ooo.gameObject.tag == "Player")
        {
            Destroy(gameObject); 
            GameManager.instance.PlayerHPG(damage * 3);
        }
    }
}
