using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;

    [Header("Other")]
    public AudioManager audioManager;

    public ScoreScript scoreScript;

    public PuckScript puckScript;
    public PugMovement playerMovement;
    public AIMovementScript aiScript;

    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (didAiWin)
        {
            audioManager.PlayLostGame();
            WinTxt.SetActive(false);
            LoseTxt.SetActive(true);
        }
        else
        {
            audioManager.PlayWonGame();
            WinTxt.SetActive(true);
            LoseTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    
     }

    public void MainMenuBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
