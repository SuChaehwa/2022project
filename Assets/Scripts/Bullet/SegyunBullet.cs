using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegyunBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float waitTime = 0.5f;
    public float waitTime2 = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Hihi");
    }

    // Update is called once per frame
    void Update()
    {
        //¿Ü¾ÊµÇ
    }

    IEnumerator Hihi()
    {
        for(int i = 0; i<3;i++)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(waitTime);
        }

        yield return new WaitForSecondsRealtime(Random.Range(waitTime2,0.2f));
        StartCoroutine("Hihi");
    }
}
