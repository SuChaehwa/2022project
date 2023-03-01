using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonM : MonoBehaviour
{
    public void Stage2()
    {
        SceneManager.LoadScene(2);
    }
    public void Stage1()
    {
        SceneManager.LoadScene(1);
    }
    public void Startmove()
    {
        SceneManager.LoadScene(0);
    }
    public void EXITT()
    {
        Application.Quit();
    }
    public void ScoreMove()
    {
        SceneManager.LoadScene(5);
    }
    public void Stage()
    {
        SceneManager.LoadScene(3);
    }
}
