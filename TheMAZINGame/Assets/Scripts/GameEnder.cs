using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnder : MonoBehaviour
{
    Text textNameCaption;
    Text textName;
    GameObject i_f;
    GameObject buttonSubmit;
    int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("currentScore"))
        {
            currentScore = PlayerPrefs.GetInt("currentScore");
        }

        //SceneManager.UnloadSceneAsync("MainScene");
        var texts = FindObjectsOfType<Text>();
        i_f = GameObject.Find("inputName");
        buttonSubmit = GameObject.Find("buttonSubmit");

        //find text objects to hide/unhide
        foreach (Text t in texts)
        {
            if (t.text == "Enter Your Name:")
            {
                textNameCaption = t;

            }
            else
            {
                if (t.text == "")
                {
                    textName = t;
                }
            }
        }
        //GameObject.Find("inputName").SetActive(false);
        i_f.SetActive(false);
        buttonSubmit.SetActive(false);
        textNameCaption.enabled = false;

        StartCoroutine(WaitCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendToLeaderboard()
    {
        Debug.Log("headed to leaderboard");
        //get current score to set
        currentScore = PlayerPrefs.GetInt("currentScore");
        //set name and current score
        //having trouble getting all names/current scores,
        //may need to redo this at leaderboard time.
        PlayerPrefs.SetInt(textName.text, currentScore);
        //we dont have a leaderboard, just end the whole thing.
        Application.Quit();
    }

    IEnumerator WaitCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        GameObject.Find("imageEnd").SetActive(false);
        textNameCaption.enabled = true;
        i_f.SetActive(true);
        buttonSubmit.SetActive(true);

        Debug.Log("final score: " + currentScore);
        

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
