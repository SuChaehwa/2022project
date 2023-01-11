using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float waitTime = 0.5f;
    public float waitTime2 = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Hihi()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(waitTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D ooo)
    {
        if (ooo.gameObject.tag == "wall" || ooo.gameObject.tag == "enemy") StartCoroutine("Hihi");
    }

}
