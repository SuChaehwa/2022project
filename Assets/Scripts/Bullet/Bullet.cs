using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float waitTime = 0.5f;
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
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(waitTime);
        StartCoroutine("Hihi");
    }


}
