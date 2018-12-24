using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

    public string playScene;
    public string creditScene;
	
	public void PlayButtonPressed()
    {
        SceneManager.LoadScene(playScene);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void CreditsButtonPressed()
    {
        SceneManager.LoadScene(creditScene);
    }
}
