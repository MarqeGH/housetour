using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    [SerializeField] TMP_Text scoreBoard;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.SetText("Score: " + score);
    }

    public void IncrementScore(int scorePoints)
    {
        score += scorePoints;
    }
}
