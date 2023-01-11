using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            instance = this;
        }
    }

    public Slider hPBar;
    public Slider painBar;

    public GameObject shield;

    public SpriteRenderer shieldren;
    public SpriteRenderer playerren;

    public int score = 0;
    public int playerHP = 100;
    public int pain = 0;

    public float shieldTime;

    public Text scoreText;

    public bool isMuJuck = false;
    public bool isShield2 = false;
    public bool isBossTime = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shieldmanage();

        if(Input.GetKeyUp(KeyCode.Q))
        {
            score += 200;
            Score(0);
        }
    }
    
    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(0);
    }

    public void Score(int add)
    {
        score += add;
        scoreText.text = "SCORE | " + score;
        if(score > 1000) isBossTime= true;
    }

    public void PlayerHPG(int damage)
    {
        hPBar.value -= damage;
        if(hPBar.value <= 0)
        {
            StartCoroutine("Die");
        }
    }

    public void PainG(int damage)
    {
        painBar.value += damage;
        if (painBar.value >= 100)
        {
            StartCoroutine("Die");
        }
    }

    private int a;
    public void Shieldmanage()
    {
        shieldTime -= Time.deltaTime;

        if(shieldTime > 0)
        {
            if(shieldTime < 0.5f && !isShield2)
            {
                isShield2= true;
                StartCoroutine(Shield2());
            }
            else
            {
                isMuJuck = true;
                shield.SetActive(true);
            }
        }
        else
        {
            isMuJuck = false;
            shield.SetActive(false);
        }
    }

    public IEnumerator Shield2()
    {       
        shieldren.enabled = false;
        yield return new WaitForSecondsRealtime(0.1f);
        shieldren.enabled = true;
        isShield2 = false;
    }
    public void Mumanage()
    {
        StartCoroutine("Mu");
    }

    public IEnumerator Mu()
    {
        isMuJuck = true;
        for (int i = 1; i <= 15; i++)
        {
            if(i%2!=0) playerren.enabled = false;
            else playerren.enabled = true;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        isMuJuck = false;
        playerren.enabled = true;
    }

}
