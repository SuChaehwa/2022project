using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ENDSCORE : MonoBehaviour
{
    public Text score;
    void Start()
    {
        score.text = "Score | " + GameManager.instance.lastScore; 
    }
}
