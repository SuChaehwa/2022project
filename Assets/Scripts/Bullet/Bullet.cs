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

        for(int i=0;i<GameManager.instance.bulletLevel; i++)
        {
            switch(GameManager.instance.bulletLevel)
            {
                case 1:
                    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bulletPrefab, new Vector2(transform.position.x-0.2f, transform.position.y), Quaternion.identity);
                    Instantiate(bulletPrefab, new Vector2(transform.position.x + 0.2f, transform.position.y), Quaternion.identity);
                    break;
                case 3:
                    for(int j =-1; j<2; j++)
                    {
                        Instantiate(bulletPrefab, new Vector2(transform.position.x , transform.position.y), Quaternion.Euler(0f, 0f, j*-7));
                    }

                    break;
                case 4:
                    for (int j = 0; j < 4; j++)
                    {
                        
                        Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0f, 0f, -9+j*6));
                        
                    }
                    break;
                case 5:
                    for (int j = -2; j < 3; j++)
                    {
                        Instantiate(bulletPrefab, new Vector2(transform.position.x , transform.position.y), Quaternion.Euler(0f, 0f, j * -5));
                        //yield return new WaitForSecondsRealtime(0.025f);
                    }
                    break;

            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return new WaitForSecondsRealtime(waitTime-0.1f);
        StartCoroutine("Hihi");
    }


}
