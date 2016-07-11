using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    // Fade time
    private float fadeTime;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Main Menu Buttons

    // Character Select
    public void PlayButton()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    // Controls 
    public void ControlsButton()
    {
        SceneManager.LoadScene("Controls");
    }
    // Options
    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");
    }
    // Credits
    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
    // Back
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
