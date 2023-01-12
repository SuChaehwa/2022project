using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WBlood : Blood
{
    public GameObject[] items;

    public void OnTriggerEnter2D(Collider2D ooo)
    {
        if (ooo.gameObject.tag == "playerBullet")
        {
            HP--;
            Destroy(ooo.gameObject);
            if (HP <= 0)
            {
                Destroy(gameObject);
                Instantiate(items[Random.Range(0, 4)]);
            }
        }
    }
}
