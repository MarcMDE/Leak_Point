using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    [SerializeField] GameObject credits;

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void HideCredits()
    {
        credits.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("ConsoleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
