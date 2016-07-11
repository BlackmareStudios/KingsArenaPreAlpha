using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LastManStanding : MonoBehaviour {
    public bool isPlayer1Alive;
    public bool isPlayer2Alive;

    public bool isDraw;

    public Texture2D p1WinBoard;
    public Texture2D p2WinBoard;
    public Texture2D drawBoard;

    // Use this for initialization
    void Start () {
        isPlayer1Alive = true;
        isPlayer2Alive = true;

        isDraw = true;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnGUI()
    {
        if (isPlayer1Alive == true && isPlayer2Alive == false)
        {
            //print("P1 WON!");
            GUI.Label(new Rect((Screen.width / 2 - 100), 200, 200, 75), p1WinBoard);
            isDraw = false;
            StartCoroutine("GoBackCharacterSelect");
        }

        if (isPlayer1Alive == false && isPlayer2Alive == true)
        {
            //print("P2 WON!");
            GUI.Label(new Rect((Screen.width / 2 - 100), 200, 200, 75), p2WinBoard);
            isDraw = false;
            StartCoroutine("GoBackCharacterSelect");
        }

        if (isPlayer1Alive == false && isPlayer2Alive == false && isDraw == true)
        {
            //print("DRAW");
            GUI.Label(new Rect((Screen.width / 2 - 100), 200, 200, 75), drawBoard);
            StartCoroutine("GoBackCharacterSelect");
        }
    }

    IEnumerator GoBackCharacterSelect()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("CharacterSelect");
    }
}
