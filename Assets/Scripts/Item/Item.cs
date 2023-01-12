using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed=2;
    public Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Random.Range(-2f, 2f), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -speed * Time.deltaTime));
    }
}
