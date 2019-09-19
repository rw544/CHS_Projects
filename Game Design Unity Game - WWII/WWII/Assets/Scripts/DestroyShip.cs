using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShip : MonoBehaviour {
    public GameObject explosion;
    private GameController gameController;
    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();

            if (gameController == null)
            {

                Debug.Log("Cannot find 'GameController' object");
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary")
        {
            return;
        }
        //Debug.Log("Nuke Collider " + other.name);

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
           
        }

        if (other.tag == "Player")
        {
            Debug.Log("Game over tag " + other.name);
            gameController.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
           
        }
        
    }
}
