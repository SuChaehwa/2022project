using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float speed = 5f;
    public float playerHP = 100;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemtBullet")
        {
            playerHP -= 5;
        }
    }

}
