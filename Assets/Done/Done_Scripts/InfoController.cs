using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoController : MonoBehaviour {

    public Text InfoText;

    private string info;
    private string objectInfo = "You are the last fighter ship of The Prime Battalion, " +
        "seeking revenge against The Wrixiors for destring you home world! \n\n" +
        "You got wind that they're located somewhere in the Ocrelun Astroid Belt... \n\n" +
        "However, you have been spotted byt the enemy, and now fighting for you live! \n\n" +
        "Will you make it through alive or will your race end here with you?";
    private string moveInfo = "Use 'w', 'a', 's', 'd' or the arrow keys to more your ship around.";
    private string shootInfo = "Use the space bar or the left mouse button to shoot.";
    private string astroidInfo = "Be careful, of the smaller pieces when they get destroid.\n\n" + "The astroids are worth 5 points.";
    private string defaultEnemyInfo = "They are the basic enemy and first line of defence.\n\n" + "This enemy ship is worth 10 points.";
    private string tridentEnemyInfo = "They are the second line of defence, they shoot and move faster then the normal ship.\n\n" +
        "This enemy ship is worth 15 points.";

	// Use this for initialization
	void Start () {
        info = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (info == "Objective")
        {
            setInfoText(objectInfo);
        }
        else if (info == "Move")
        {
            setInfoText(moveInfo);
        }
        else if (info == "Shoot")
        {
            setInfoText(shootInfo);
        }
        else if (info == "Astroid")
        {
            setInfoText(astroidInfo);
        }
        else if (info == "Enemy1")
        {
            setInfoText(defaultEnemyInfo);
        }
        else if (info == "Enemy2")
        {
            setInfoText(tridentEnemyInfo);
        }
        else
        {
            setInfoText("");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    private void setInfoText(string text)
    {
        InfoText.text = text;
    }

    public void setInfo(string text)
    {
        info = text;
    }
}
