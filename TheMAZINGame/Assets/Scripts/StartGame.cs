using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        //trying to set the button text color of "Resume" to yellow after the scene has been loaded.
        //cant seem to access the button and its text color
        GameObject buttonText = GameObject.FindGameObjectWithTag("resumeButton");
        if (SceneManager.sceneCount > 1)
        {

            
            //need to set color here to
            //E9C536

        }
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
