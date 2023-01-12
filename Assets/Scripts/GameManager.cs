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
    public GameObject Boss;

    public SpriteRenderer shieldren;
    public SpriteRenderer playerren;

    public int score = 0;
    public int playerHP = 1000;
    public int pain = 0;
    public int bulletLevel = 1;

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

        ccc();
    }

    private void ccc()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Score(1000);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            PlayerHPG(20);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {

            PainG(20);
        }
        if (Input.GetKeyUp(KeyCode.V))
        {

            if(bulletLevel<5) bulletLevel++;
        }
    }
    
    IEnumerator Die()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3);
        GameOver();
    }

    public void Score(int add)
    {
        score += add;
        scoreText.text = "SCORE | " + score;
        if (score > 10000)
        {
            isBossTime = true;
            Boss.SetActive(true);
        }
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
        if (painBar.value >= 1000)
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


    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
