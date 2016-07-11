using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArenaCountDownStart : MonoBehaviour {

    private float timeLeft = 3.5f;       //3.5f
    public bool startMatch;

    // Display the game start timer in the game world
    public Text gameStartText;

    // Use this for initialization
    void Start () {
        startMatch = false;
	}
	
	// Update is called once per frame
	void Update () {
        //print(startMatch);

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            //startMatch = true;
        }

        if (timeLeft < 3 && startMatch == false)
        {
            if (timeLeft > 1)
            {
                gameStartText.text = (timeLeft.ToString("0"));
            }
            else
            {
                gameStartText.text = (timeLeft.ToString("FIGHT!"));
                StartCoroutine("StartMatch");
            }
        }
    }

    IEnumerator StartMatch()
    {
        yield return new WaitForSeconds(0.5f);
        gameStartText.text = ("");
        startMatch = true;
    }
}
