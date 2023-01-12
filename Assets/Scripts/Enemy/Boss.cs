using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boss : EnemyHP
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) Die();
    }

    IEnumerator Attack()
    {
        yield return new WaitForSecondsRealtime(Random.Range(3f,5f));
        switch (Random.Range(1, 3))
        {
            case 1:
                StartCoroutine(Attack1(Random.Range(2, 5)));
                break;
            case 2:
                StartCoroutine(Attack2());
                break;
        }
    }

    IEnumerator Attack1(int a)
    {
        for (int j = -a; j < a+1; j++)
        {
            Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0f, 0f, j * -5));
            yield return new WaitForSecondsRealtime(0.015f);
        }
        if (HP > 0) StartCoroutine(Attack());
    }

    IEnumerator Attack2()
    {
        for (int j = 0; j < 36; j++)
        {
            Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0f, 0f, j * 10));
            yield return new WaitForSecondsRealtime(0.03f);
        }
        yield return new WaitForSecondsRealtime(1.08f);
        if (HP > 0) StartCoroutine(Attack());
    }

    public void Die()
    {
        Destroy(gameObject);
        GameManager.instance.GameOver();
    }

}
