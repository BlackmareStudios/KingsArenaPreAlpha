using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // Listen and change the pause menu content canvas variables
    public GameObject pauseContentObject;

    // Fade time
    private float fadeTime;

    // Use this for initialization
    void Start () {
        pauseContentObject = GameObject.Find("PauseMenuContent");
        pauseContentObject.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            // Show pause menu content
            pauseContentObject.gameObject.SetActive(true);

            // Pause the entire game
            Time.timeScale = 0;
        }
    }


    // Resume button
    public void ResumeButton()
    {
        //print("BUTTON1");
        // Switch timescale to 1 and disable to pause menu contents
        pauseContentObject.gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    // Character select button
    public void CharacterSelectButton()
    {
        //print("BUTTON2");
        // Switch timescale to 1 and disable to pause menu contents
        pauseContentObject.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("CharacterSelect");
    }


    // Main menu button
    public void MainMenuButton()
    {
        //print("BUTTON3");
        // Switch timescale to 1 and disable to pause menu contents
        pauseContentObject.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
