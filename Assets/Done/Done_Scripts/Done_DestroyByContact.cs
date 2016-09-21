using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
    private Done_PlayerController player;
	private Done_GameController gameController;

	void Start ()
	{
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Done_PlayerController>();
        }
        if (player == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
            if (player != null && player.health <= 0)
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }
		}
		
		gameController.AddScore(scoreValue);
        if (other.tag != "Bolts" && player.health <= 0)
        {
            Destroy(other.gameObject);
        }
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
		//Destroy (other.gameObject);
		Destroy (gameObject);
	}
}