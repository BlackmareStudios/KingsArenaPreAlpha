using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuMusic : MonoBehaviour {

    static bool AudioBegin = false;

    void Awake()
    {
        if (!AudioBegin)
        {
            //audio.Play();
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // scenes that are not considered main menu
        if (SceneManager.GetActiveScene().name == "arena1")
        {
            //audio.Stop();
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;
        }
        else
        {
            //AudioBegin = false;
            Awake();
        }
    }
}
