using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscListener : MonoBehaviour
{
    //int first_run = 0;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }

    }
}
