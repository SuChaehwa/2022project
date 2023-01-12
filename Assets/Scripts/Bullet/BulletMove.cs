using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "enemyBullet" || gameObject.CompareTag("BossBullet")) speed *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        float Y = speed * Time.deltaTime;
        transform.Translate(new Vector2(0, Y));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish")) Destroy(gameObject);
    }

}
