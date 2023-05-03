using Assets.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializationScript : MonoBehaviour
{
    [SerializeField]
    ChangeScoreScript changeScoreScript;

    [SerializeField]
    BallPushingScript ballPushingScript;

    [SerializeField]
    Canvas pauseCanvas;

    [SerializeField]
    private Canvas uiCanvas;

    private bool _pauseShown;

    void Awake()
    {
    }

    private void Update()
    {
        if (!uiCanvas.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseShown)
            {
                _pauseShown = false;
                ResumeGame();
            }
            else
            {
                _pauseShown = true;
                Time.timeScale = 0.0f;
                pauseCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);

        changeScoreScript.RedScore = 0;
        changeScoreScript.BlueScore = 0;

        ballPushingScript.ResetCooldowns();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}