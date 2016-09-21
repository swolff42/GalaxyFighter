using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
    public Text timeClock;
	
	private bool gameOver;
	private bool restart;
	private int score;
    private float startTime;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
        startTime += Time.time;
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
        UpdateTime();

		if (restart)
		{
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonUp("Submit"))
			{
				//Application.LoadLevel (Application.loadedLevel);
                SceneManager.LoadScene(Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
        Cursor.visible = true;
	}

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void UpdateTime()
    {
        float time = Time.time - startTime;

        int m = (int)time / 60;
        string min = m.ToString();
        string sec = (time % 60).ToString("f0");

        timeClock.text = "Time: " + min + ":" + sec;
    }
}