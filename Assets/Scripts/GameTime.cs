using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    Image bar;
    public float Progress
    {
        get
        {
            return time / totalTime;
        }
    }

    public float totalTime;
    [HideInInspector]
    public float time;

    public static GameTime Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameIsOver)
            return;

        time -= Time.deltaTime;
        bar.fillAmount = Progress;

        if(time<= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void StartGame()
    {
        time = totalTime;
    }
}
