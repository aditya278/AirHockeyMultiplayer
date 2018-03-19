using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {


    public Toggle multiPlayerToggle;

    private void Start()
    {
        multiPlayerToggle.isOn = ValueScript.IsMultiplayer;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SetMultiplayer(bool isOn)
    {
        ValueScript.IsMultiplayer = isOn;
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
