using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour {

    public Button ButtonOption1;
    public Button ButtonOption2;
    public Button ButtonOption3;
    public Button ButtonOption4;

    private string ship;

	// Use this for initialization
	void Start () {
        ship = "";
	}

    public void LoadGame()
    {
        if (ship == "Omega Fighter")
        {
            //Application.LoadLevel("Omega_Game");
            SceneManager.LoadScene("Omega_Game");
        }
        else if (ship == "Space Jet")
        {
            //Application.LoadLevel("Jet_Game");
            SceneManager.LoadScene("Jet_Game");
        }
        else if (ship == "Astra Battleship")
        {
            //Application.LoadLevel("Battleship_Game");
            SceneManager.LoadScene("Battleship_Game");
        }
        else
        {
            //Application.LoadLevel("Default_Game");
            SceneManager.LoadScene("Default_Game");
        }
    }

    public void GoMain()
    {
        //Application.LoadLevel("Main_Menu");
        SceneManager.LoadScene("Main_Menu");
    }

    public void SelectShip(string name)
    {
        ship = name;
    }
}
