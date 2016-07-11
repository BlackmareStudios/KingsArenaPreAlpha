using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ArenaSelectionScript : MonoBehaviour {
    public int selectedArena;
	// Use this for initialization
	void Start () {
        selectedArena = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //print(selectedArena);
    }

    // Arena selected
    public void Arena1Button()
    {
        selectedArena = 1;
    }
    // Arena selected
    public void Arena2Button()
    {
        selectedArena = 2;
    }
    // Arena selected
    public void Arena3Button()
    {
        selectedArena = 3;
    }
    // Arena selected
    public void PlayButton()
    {
        switch (selectedArena)
        {
            case 1:
                SceneManager.LoadScene("arena1");
                break;
            case 2:
                print("play areana 2");
                break;
            case 3:
                print("play areana 3");
                break;
        }
        //SceneManager.LoadScene("arena1");
    }
}
