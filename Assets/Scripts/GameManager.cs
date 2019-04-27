using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject endMenu;
    public GameObject moneyRain;
    public static bool gameIsOver;
    public static bool animationEnded = false;

    bool isLoading = false;

    private void Awake()
    {
        Instance = this;
        gameIsOver = false;
        animationEnded = false;
        Score.score = 0;
    }

    public void GameOver(bool waitForAnimations = false)
    {
        gameIsOver = true;

        if (waitForAnimations)
            StartCoroutine(WaitForAnimations());
        else
        {
            moneyRain.SetActive(true);
            endMenu.SetActive(true);
        }
    }

    IEnumerator WaitForAnimations()
    {
        while(!animationEnded)
        {
            yield return null;
        }

        moneyRain.SetActive(true);
        endMenu.SetActive(true);
    }

    public void NewGame()
    {
        if (isLoading)
            return;

        isLoading = true;
        SceneManager.LoadScene(0);
    }
}
