using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.shieldTime = 3;
            Destroy(gameObject);
        }
    }
}
