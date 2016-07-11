using UnityEngine;
using System.Collections;

public class AudioFileController : MonoBehaviour
{

    // Play a sound when a magician attacks
    public GameObject magicianAttackSound;

    // Play a sound when a winner is declared
    public GameObject victorySound;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Run this function when a magician attacks
    public void PlaySound(GameObject soundObj)
    {
        soundObj.GetComponent<AudioSource>().Play();
    }
}
