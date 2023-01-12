using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUp : Item
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(GameManager.instance.bulletLevel <5) GameManager.instance.bulletLevel ++;
            Destroy(gameObject);
        }
    }
}
