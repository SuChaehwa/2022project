using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float speed = 5f;
    public float Time = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        /*float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 speedNomal = (new Vector2(h, v));
        if (speedNomal.magnitude > 1)
            speedNomal = speedNomal.normalized;
        transform.Translate(speedNomal * (speed));*/

        float xInput = Input.GetAxis("Horizontal")* speed;
        float yInput = Input.GetAxis("Vertical") * speed;
        playerRigidbody.velocity = new Vector2(xInput, yInput);


        /*Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);*/

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -1.662496f, 1.664077f), Mathf.Clamp(transform.position.y, -4.286839f, 4.433f));
    }

    public void OnTriggerEnter2D(Collider2D ooo)
    {
        if (ooo.gameObject.tag == "enemyBullet" )
        {
            Destroy(ooo.gameObject);
            if (!GameManager.instance.isMuJuck)
            {
                GameManager.instance.PlayerHPG(2);
                GameManager.instance.Mumanage();
            }
        }
        if (ooo.gameObject.tag == "armG" && !GameManager.instance.isMuJuck)
        {
            GameManager.instance.PlayerHPG(5);
            GameManager.instance.Mumanage();
        }
    }
}
