using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int currentScore;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("reset score to 0");
        currentScore = 0;
        PlayerPrefs.SetInt("currentScore", 0);


        var texts = FindObjectsOfType<Text>();

        //find text objects to hide/unhide
        foreach (Text t in texts)
        {
            if (t.text == "0")
            {
                scoreText = t;
            }
        }
    }

    void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int score)
    {
        currentScore = currentScore + score;
        scoreText.text = currentScore.ToString();
        PlayerPrefs.SetInt("currentScore", currentScore);
    }

    public void SubtractFromScore(int score)
    {
        currentScore = currentScore - score;
        scoreText.text = currentScore.ToString();
        PlayerPrefs.SetInt("currentScore", currentScore);
    }
}
