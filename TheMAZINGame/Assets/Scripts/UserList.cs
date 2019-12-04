using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserList : MonoBehaviour
{

    public GameObject scoreEnterPrefab;

    Scoreboard scoreboard;

    int lastChange;

    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GameObject.FindObjectOfType<Scoreboard>();

       
        lastChange = scoreboard.GetChangeCount();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreboard == null)
        {
            //Debug.LogError("You forgot to add scoreboard component to game object.");
            return;
        }

        
        if(scoreboard.GetChangeCount() == lastChange)
        {
            // no change has been made
            return;
        }

        lastChange = scoreboard.GetChangeCount();
        

        // removes name we already have so it doesn't keep repeating in the foreach loop
        while(this.transform.childCount > 0)
        {
            // get first child
            Transform c = this.transform.GetChild(0);
            // kill it
            c.SetParent(null);
            Destroy(c.gameObject);
        }

        // get usernames from scoreboard
        string[] names = scoreboard.GetUsernames();

        // populates the leaderboard
        foreach (string name in names)
        {
            GameObject go = (GameObject)Instantiate(scoreEnterPrefab);
            go.transform.SetParent(this.transform);

            // changes the name on the leaderboard
            go.transform.Find("nameText").GetComponent<Text>().text = name;
            // making the int score into a string and also displaying it on leaderboard
            go.transform.Find("scoreText").GetComponent<Text>().text = scoreboard.GetScore(name).ToString();
        }
    }
}
