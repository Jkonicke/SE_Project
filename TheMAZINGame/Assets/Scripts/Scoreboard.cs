using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{

    Dictionary<string, int> userScores;

    int changeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetScore("CHRIS", 9999);
        SetScore("JACOB", 5000);
        SetScore("MARCO", 4999);
        SetScore("MADISON", 1);
        SetScore("KEVIN", 4500);

        //Debug.Log(GetScore("marco"));
    }

    // initializing the dictionary of userscores so it does not have null value
    void Initialize()
    {
        if(userScores != null)
        {
            return;
        }
        userScores = new Dictionary<string, int>();
    }

    // a get method to get the username
    public int GetScore(string username)
    {
        Initialize();
        
        // if user score does not exist then exit
        if(userScores.ContainsKey(username) == false)
        {
            return 0;
        }
       
        return userScores[username];
    }

    // a set method for the username and score
    public void SetScore(string username, int score)
    {
        Initialize();

        changeCount++;
        
        // if user does not exist then set the username
        /*
        if(userScores.ContainsKey(username) == false)
        {
            userScores[username] = new Dictionary<string, int>();
        }
        */
        // otherwise set the score to the username
        userScores[username] = score;
    }

    // a method in case we need to change the score
    public void ChangeScore(string username, int score)
    {
        Initialize();

        int current = GetScore(username);
        SetScore(username, current + score);
    }

    // this method gets usernames and sorts by score
    public string[] GetUsernames()
    {
        Initialize();
        // using System.Linq helps us convert dictionary keys to array of strings
        return userScores.Keys.OrderByDescending(n => GetScore(n)).ToArray();
    }
    
    // this will optimize the leaderboard
    // will only reload the leaderboard if the score count changes
    public int GetChangeCount()
    {
        return changeCount;
    }
}
