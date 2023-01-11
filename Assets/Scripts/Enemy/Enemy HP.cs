using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int HP=5;
    public int damage = 15;
    public int score = 100;
    public Rigidbody2D rd;
    // Start is called before the first frame update

    public void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Random.Range(-2f, 2f),transform.position.y);
    }
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
                GameManager.instance.Score(score);
            }
        }
        else if (collision.gameObject.tag == "Shield") Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D ooo)
    {
        if (ooo.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
            if(!GameManager.instance.isMuJuck)
            {
                GameManager.instance.PlayerHPG(damage * 3);
                GameManager.instance.Mumanage();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D ooo)
    {
        if (ooo.gameObject.tag == "pain")
        {
            Destroy(gameObject);
            GameManager.instance.PainG(damage/2);
        }
    }
}