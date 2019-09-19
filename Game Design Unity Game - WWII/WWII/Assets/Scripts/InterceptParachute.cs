using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptParachute : MonoBehaviour {
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
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
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary")
        {
           return;
        }
        Debug.Log("Parachute Collider " + other.name);

        gameController.AddScore(scoreValue);

        // Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
