using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    int firstRun = 0;
    Text textResume;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        //need to set color here to
        //E9C536
        /*
        var texts = FindObjectsOfType<Text>();
        foreach (Text t in texts)
        {
            if (t.text == "Resume")
            {
                textResume = t;
            }
        }
        textResume.color = Color.gray;
        //new Color(233 / 255f, 197 / 255f, 54 / 255f);
        */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void LoadLeaderboardScene()
    {
        SceneManager.LoadScene("Leaderboard", LoadSceneMode.Single);
    }

    public void UnloadMenu()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
