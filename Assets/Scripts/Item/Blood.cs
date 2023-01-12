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
    protected void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Random.Range(-2f, 2f), transform.position.y);
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.Translate(new Vector2(LR * speed2 * Time.deltaTime, -speed * Time.deltaTime));
        if (rd.velocity.y > 0) rd.velocity = new Vector2 (rd.velocity.x, -rd.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D ooo)
    {
        if (ooo.gameObject.tag == "wall" || ooo.gameObject.tag == "enemy" || ooo.gameObject.tag == "Player" ||
            ooo.gameObject.tag == "blood" || ooo.gameObject.CompareTag("Boss"))
            LR *= -1;
    }

    private void OnTriggerExit2D(Collider2D ooo)
    {
        if (ooo.gameObject.tag == "pain")
        {
            Destroy(gameObject);
        }
    }
}
