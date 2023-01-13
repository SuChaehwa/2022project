using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Boss : EnemyHP
{
    public GameObject[] enemys;
    public GameObject bulletPrefab;
    public Slider bossHPBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        BossHP();
    }

    public void BossHP()
    {
        bossHPBar.value = HP;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSecondsRealtime(Random.Range(3f,5f));
        switch (Random.Range(0, 5))
        {
            case 0:
                StartCoroutine(EnemyS());
                break;
            case 1:
                StartCoroutine(Attack1(Random.Range(2, 5)));
                break;
            case 2:
                StartCoroutine(Attack2());
                break;
            case 3:
                StartCoroutine(Attack3(Random.Range(2, 5)));
                break;
            case 4:
                StartCoroutine(Attack4());
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

    IEnumerator Attack3(int a)
    {
        for (int j = -a; j < a + 1; j++)
        {
            Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0f, 0f, j * 5));
            yield return new WaitForSecondsRealtime(0.015f);
        }
        if (HP > 0) StartCoroutine(Attack());
    }

    IEnumerator Attack4()
    {
        for(int i=0;i<3;i++)
        {
            for (int j = 0; j < 18; j++)
            {
                Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0f, 0f, j * 20 + i*10));
            }
            yield return new WaitForSecondsRealtime(0.3f);
        }
        yield return new WaitForSecondsRealtime(1.08f);
        if (HP > 0) StartCoroutine(Attack());
    }
    IEnumerator EnemyS()
    {
        for (int j = 0; j < 5; j++)
        {
            Instantiate(enemys[Random.Range(0, 4)]);
            yield return new WaitForSecondsRealtime(0.015f);
        }
        if (HP > 0) StartCoroutine(Attack());
    }

    public void Die()
    {
        if (HP <= 0)
        {
            Debug.Log("GameOver BossDie");
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
        
    }

}
