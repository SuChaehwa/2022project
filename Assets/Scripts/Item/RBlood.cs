using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBlood : Blood
{

    public void OnTriggerEnter2D(Collider2D ooo)
    {
        if (ooo.gameObject.tag == "enemyBullet" || ooo.gameObject.tag == "armG" || ooo.gameObject.tag == "enemy" || ooo.gameObject.tag == "Player")
        {
            HP--;
            Destroy(ooo.gameObject);
        }

        if (HP <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.PainG(15);
        }
    }
}
