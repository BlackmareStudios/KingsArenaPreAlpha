using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {
    private int dropSpeed;
    public GameObject explosionPrefab;
    // Use this for initialization
    void Start () {
        dropSpeed = 20;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y >= 1)
        {
            this.transform.Translate(Vector3.down * Time.deltaTime * dropSpeed);
        }
        else
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
