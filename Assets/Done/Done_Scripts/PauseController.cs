using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    public GameObject PausePanel;

    private bool isPause;
    private bool gameOver;
    private Done_GameController gameController;

	// Use this for initialization
	void Start () {
        isPause = false;
        gameOver = false;
        PauseGame(isPause);
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }
        else
        {
            Debug.Log("Cannot fine 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
        gameOver = gameController.IsGameOver();
        if(gameOver == false)
        {
            if(Input.GetButtonUp("Cancel") || Input.GetKeyDown(KeyCode.P))
            {
                isPause = !isPause;
                PauseGame(isPause);
            }
        }
	}

    public void PauseGame(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0.0f;
            PausePanel.SetActive(true);
            AudioListener.pause = true;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            PausePanel.SetActive(false);
            AudioListener.pause = false;
            Cursor.visible = false;
        }
    }

    public void ResumeGame()
    {
        isPause = !isPause;
        PauseGame(isPause);
    }

    public void Restart()
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void MainMenu()
    {
        //Application.LoadLevel("Main_Menu");
        SceneManager.LoadScene("Main_Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
