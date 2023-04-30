using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChangeScoreScript : MonoBehaviour
{
    private int _redScore;
    private int _blueScore;

    [SerializeField]
    private RestoreObjectsPositionScript _positionScript;

    public int RedScore
    {
        get => _redScore;
        set
        {
            _redScore = value;
            redScoreText.text = _redScore.ToString();
            _positionScript.RestoreObjectsPositions();
        }
    }
    public int BlueScore
    {
        get => _blueScore;
        set
        {
            _blueScore = value;
            blueScoreText.text = _blueScore.ToString();
            _positionScript.RestoreObjectsPositions();
        }
    }

    [SerializeField] private Text redScoreText;
    [SerializeField] private Text blueScoreText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}