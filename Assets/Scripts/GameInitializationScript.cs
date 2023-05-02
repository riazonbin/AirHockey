using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializationScript : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
}