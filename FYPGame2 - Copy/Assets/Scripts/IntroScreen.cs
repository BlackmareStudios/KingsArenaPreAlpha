using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour {

    private float fadeTime;
    
	void Start () {
        StartCoroutine("GoToMainMenu");
    }
	
	IEnumerator GoToMainMenu()
    {
        // Wait for a few seconds before loading into the main menu screen
        yield return new WaitForSeconds(3.5f);
        // fade out the game and load a new level
        fadeTime = GameObject.Find("GameController").GetComponent<FadeSceneScript>().BeginFade(1);
        //yield return new WaitForSeconds(fadeTime);
        StartCoroutine("StopAndFade");
    }

    IEnumerator StopAndFade()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
