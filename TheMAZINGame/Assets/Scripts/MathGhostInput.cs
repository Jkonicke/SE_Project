using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathGhostInput : MonoBehaviour
{
    Text textCorrect;
    Text textWrong;
    int currentScore;
    private Score scoreScene;

    //public RectTransform questionPanel;

    public static bool isCorrect = false;
    

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("ScoreScene", LoadSceneMode.Additive);

        if (PlayerPrefs.HasKey("currentScore"))
        {
            currentScore = PlayerPrefs.GetInt("currentScore");
        }

        //var questionPanel = FindObjectOfType<RectTransform>();
        var texts = FindObjectsOfType<Text>();

        //find text objects to hide/unhide
        foreach (Text t in texts)
        {
            if (t.text == "Correct!")
            {
                textCorrect = t;

            }
            else
            {
                if (t.text == "Try Again")
                {
                    textWrong = t;
                }
            }
        }
        textCorrect.enabled = false;
        textWrong.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitAnswer()
    {
        var field = FindObjectOfType<InputField>();

        if (field.textComponent.text != "14")
        {
            Debug.Log("WRONG");
            /*
            currentScore = currentScore - 100;
            Debug.Log("WRONG on math ghost currentScore: " + currentScore);
            scoreScene = GameObject.Find("ScoreUpdater").GetComponent<Score>();
            scoreScene.UpdateScore(currentScore);
            */
            scoreScene = GameObject.Find("ScoreUpdater").GetComponent<Score>();
            scoreScene.SubtractFromScore(100);
            textCorrect.enabled = false;
            textWrong.enabled = true;
            StartCoroutine(WaitCoroutine());
        }
        else
        {
            Debug.Log("RIGHT");
            /*
            currentScore = currentScore + 1000;
            PlayerPrefs.SetInt("currentScore", currentScore);
            Debug.Log("after math ghost currentScore: " + currentScore);
            */
            scoreScene = GameObject.Find("ScoreUpdater").GetComponent<Score>();
            scoreScene.AddToScore(1000);
            textWrong.enabled = false;
            textCorrect.enabled = true;
            isCorrect = true;
            StartCoroutine(WaitCoroutine());
        }
    }

    IEnumerator WaitCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        textWrong.enabled = false;
        textCorrect.enabled = false;
        if (isCorrect)
        {
            SceneManager.UnloadSceneAsync("MathGhostScene");
        }
    }
}
