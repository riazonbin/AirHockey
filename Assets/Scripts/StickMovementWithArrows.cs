using Assets.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMovementWithArrows : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var target = transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            target.y += 5;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            target.x += 5;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            target.x -= 5;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            target.y -= 5;
        }

        _rigidBody.MovePosition(Vector3.MoveTowards(transform.position, target, Game.StickSpeedDistance));
    }
}