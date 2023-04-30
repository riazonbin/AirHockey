using System;
using Assets.StaticData;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public ChangeScoreScript changeScoreScript;
    private Rigidbody2D _rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(Math.Min(Math.Abs(_rigidBody.velocity.x), Game.PuckMaxSpeed) * Math.Sign(_rigidBody.velocity.x), Math.Min(Math.Abs(_rigidBody.velocity.y), Game.PuckMaxSpeed) * Math.Sign(_rigidBody.velocity.y));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("RedGate"))
        {
            changeScoreScript.BlueScore++;
        }
        
        if (col.gameObject.CompareTag("BlueGate"))
        {
            changeScoreScript.RedScore++;
        }
    }
}
