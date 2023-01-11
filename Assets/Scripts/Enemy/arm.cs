using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm : MonoBehaviour
{
    public Collider2D co;

    // Start is called before the first frame update
    void Start()
    {
        co = GetComponent<Collider2D>();

        StartCoroutine("Hihi");
    }

    IEnumerator Hihi()
    {
        co.enabled = true;
        yield return null;
        co.enabled = false;
        yield return new WaitForSecondsRealtime(0.3f);
        StartCoroutine("Hihi");
    }
}
