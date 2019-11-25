// This script allows you to load a second Scene as an Additive Scene. Click the first Button (Load Scene Button) to load the Additive Scene. Even though the second Scene loads, the first Scene remains the active Scene.
// If you press the second Button (Set Active Button), it sets the second Scene as the active Scene (and outputs the current active Scene to the console)


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool m_SceneLoaded;
    public Button m_LoadSceneButton, m_SetActiveButton;

    void Awake()
    {
        // shortcut
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
        // end shortcut

        /*
        // Outputs the current active Scene to the console
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);

        // Check that this Button exists
        if (m_LoadSceneButton != null)
        {
            // Fetch the Button from the Inspector. Make sure to set this in the Inspector window
            Button loadButton = m_LoadSceneButton.GetComponent<Button>();

            // Call the LoadScene2Button() function when this Button is clicked
            loadButton.onClick.AddListener(LoadSceneButton);
        }

        if (m_SetActiveButton != null)
        {
            Button buttonTwo = m_SetActiveButton.GetComponent<Button>();
            buttonTwo.onClick.AddListener(SetActiveSceneButton);
        }
    }

    // Load the Scene when this Button is pressed
    void LoadSceneButton()
    {
        // Check that the second Scene hasn't been added yet
        if (m_SceneLoaded == false)
        {
            // Loads the second Scene
            SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);

            // Outputs the name of the current active Scene.
            // Notice it still outputs the name of the first Scene
            Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);

            // The Scene has been loaded, exit this method
            m_SceneLoaded = true;
        }
    }

    // Change the newly loaded Scene to be the active Scene if it is loaded
    void SetActiveSceneButton()
    {
        // Allow this other Button to be pressed when the other Button has been pressed (Scene 2 is loaded)
        if (m_SceneLoaded == true)
        {
            // Set Scene2 as the active Scene
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));

            // Ouput the name of the active Scene
            // See now that the name is updated
            Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        }*/
    }
}
