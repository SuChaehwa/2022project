using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject[] items;
    public float  WaitTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpqwnE");
        StartCoroutine("SpqwnI");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpqwnE()
    {
        Instantiate(enemys[Random.Range(0,4)]);
        yield return new WaitForSecondsRealtime(Random.Range(WaitTime, WaitTime+1f));
        if(!GameManager.instance.isBossTime) StartCoroutine("SpqwnE");
    }
    IEnumerator SpqwnI()
    {
        if (Random.Range(0, 5) == 0)
        {
            Instantiate(items[Random.Range(0, 1)]);
        }
        yield return new WaitForSecondsRealtime(Random.Range(WaitTime, WaitTime + 1f));
        StartCoroutine("SpqwnI");
    }
}
