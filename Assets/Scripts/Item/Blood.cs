using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public float speed;
    public float speed2;
    public int LR = 1;
    public Rigidbody2D rd;
    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Random.Range(-2f, 2f), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(LR * speed2 * Time.deltaTime, -speed * Time.deltaTime));
    }

    public void OnCollisionEnter2D(Collision2D ooo)
    {
        if (ooo.gameObject.tag == "wall" || ooo.gameObject.tag == "enemy") LR *= -1;
    }
}
