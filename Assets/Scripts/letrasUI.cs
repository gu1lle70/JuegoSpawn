using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class letrasUI : MonoBehaviour
{
    public void OnButtonPressJugar()
    {
        SceneManager.LoadScene("Arriba");
        Time.timeScale = 1.0f;

    }
    public void OnButtonPressGimnasio()
    {
        SceneManager.LoadScene("Gimnasio");
        Time.timeScale = 1.0f;

    }
    public void OnButtonPressExit()
    {

        SceneManager.LoadScene("Start");

    }
    public void OnButtonPressCredits()
    {

        SceneManager.LoadScene("Creditos");

    }
    public void OnButtonPressExitGame()
    {

        Application.Quit();

    }
    public void Options()
    {
        SceneManager.LoadScene("Options");

    }
}