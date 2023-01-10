using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int HP=5;
    public int damage = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            HP--;
            Destroy(collision.gameObject);
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
