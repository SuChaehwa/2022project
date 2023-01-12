using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainI : Item
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PainG(-5);
            Destroy(gameObject);
        }
    }
}
