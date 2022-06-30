using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;

    public TextMeshPro scoreText;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void addPoints(int pointAmount)
    {
        score += pointAmount;
        scoreText.text = "Score: " + score.ToString();
    }
}
