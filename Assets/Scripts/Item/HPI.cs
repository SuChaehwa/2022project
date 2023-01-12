using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPI : Item
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerHPG(-20);
            Destroy(gameObject);
        }
    }
}
