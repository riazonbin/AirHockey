using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializationScript : MonoBehaviour
{
    [SerializeField]
    RestoreObjectsPositionScript restoreObjectsPositionScript;

    [SerializeField]
    Canvas pauseCanvas;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            pauseCanvas.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
    }
}