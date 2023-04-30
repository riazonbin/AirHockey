using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreObjectsPositionScript : MonoBehaviour
{
    [SerializeField]
    private Transform redBall;

    [SerializeField]
    private Transform blueBall;

    [SerializeField]
    private Transform puck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestoreObjectsPositions()
    {
        redBall.position = new Vector2(0, 2.93f);
        blueBall.position = new Vector2(0, -2.93f);
        puck.position = new Vector2(0, 0);
        puck.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
