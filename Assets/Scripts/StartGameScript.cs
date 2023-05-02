using Assets.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    [SerializeField]
    Canvas gameCanvas;

    [SerializeField]
    Canvas uiCanvas;

    [SerializeField]
    Dropdown dropdown;

    private void Awake()
    {
        Time.timeScale = 0.0f;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Game.Difficulty = dropdown.value;
        uiCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
