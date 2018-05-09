using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public float bgScrollSpeed;
    void Update()
    {
        //If ESC key is pressed, quit application.
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
	public void ButtonPlay()
	{
		SceneManager.LoadScene("DemoScene");
	}
	public void ButtonInstructions()
	{
		
	}
	public void ButtonControls()
	{
		
	}
	public void ButtonExit()
	{
		QuitGame();
	}
	public void QuitGame()
	{
     // save any game data here
     #if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
	}
}
