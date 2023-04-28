using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_rigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x - 1.5f * Math.Sign(_rigidBody.velocity.x), _rigidBody.velocity.y  - 1.5f * Math.Sign(_rigidBody.velocity.y));
    }
}
