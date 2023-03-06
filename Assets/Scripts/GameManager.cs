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
    
    public GameObject bossHPBar;
    public GameObject shield;
    public GameObject Boss;

    public SpriteRenderer shieldren;
    public SpriteRenderer playerren;

    public int score = 0;
    public int playerHP = 1000;
    public int pain = 0;
    public int bulletLevel = 1;
    public int stage;//�������� ������ �޾Ƽ�

    public float shieldTime;

    public Text scoreText;
    public Text hpText;
    public Text painText;

    public bool isMuJuck = false;
    public bool isShield2 = false;
    public bool isBossTime = false;

    public string nikname;
    
    private int a;

    // Update is called once per frame
    void Update()
    {
        Shieldmanage();

        ccc();
    }

    private void ccc()
    {
        //���ھ� �ø���
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Score(1000);
        }
        //�÷��̾� Hp ������
        if (Input.GetKeyUp(KeyCode.X))
        {
            PlayerHPG(20);
        }
        //���� ������ ���̱�
        if (Input.GetKeyUp(KeyCode.C))
        {
            PainG(20);
        }
        //�� ����
        if (Input.GetKeyUp(KeyCode.V))
        {
            if(bulletLevel<5) bulletLevel++;
        }
        // ���� 3��
        if (Input.GetKeyUp(KeyCode.B))
        {
            shieldTime = 3;
        }
    }
    
    public void Score(int add)
    {
        score += add;
        scoreText.text = "SCORE | " + score;
        if (score > 10000*stage)//���� ���� �ñ� ���� -->> �������� 2�� �ν� ���ھ ������ �ۿ� ����
        {
            isBossTime = true;
            Boss.SetActive(true);
            bossHPBar.SetActive(true);
        }
    }

    public void PlayerHPG(int damage)
    {
        hPBar.value -= damage;
        hpText.text = (int)(hPBar.value / 10) + " %";
        if (hPBar.value <= 0)
        {
            Debug.Log("GameOver PlayerHp");
            GameOver();
        }
    }

    public void PainG(int damage)
    {
        painBar.value += damage;
        painText.text = (int)(painBar.value / 10) + " %";
        if (painBar.value >= 1000)
        {
            Debug.Log("GameOver Pain");
            GameOver();
        }
    }


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

    public int lastScore = 0;
    IEnumerator Die()
    {
        Time.timeScale = 0f;

        lastScore = score + (int)(hPBar.value / 10) * 100 -(int)(painBar.value / 10) * 10;

        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(4);
    }

    public void GameOver()
    {
        StartCoroutine(Die());  
    }
}
