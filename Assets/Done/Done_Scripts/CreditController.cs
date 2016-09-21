using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour {

	public void GoMain()
    {
        //Application.LoadLevel("Main_Menu");
        SceneManager.LoadScene("Main_Menu");
    }
}
