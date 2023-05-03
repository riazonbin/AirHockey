using System;
using System.Collections.Generic;
using Assets.StaticData;
using UnityEngine;
using Random = UnityEngine.Random;

public class PuckScript : MonoBehaviour
{
    public ChangeScoreScript changeScoreScript;

    [SerializeField] private List<BoxCollider2D> _ignoredColliders;
    private Rigidbody2D _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        var circleCollider = GetComponent<CircleCollider2D>();
        _ignoredColliders.ForEach(x => Physics2D.IgnoreCollision(x, circleCollider));
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(new Vector2(1600, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidBody.velocity =
            new Vector2(
                Math.Min(Math.Abs(_rigidBody.velocity.x), Game.FactPuckSpeed) * Math.Sign(_rigidBody.velocity.x),
                Math.Min(Math.Abs(_rigidBody.velocity.y), Game.FactPuckSpeed) * Math.Sign(_rigidBody.velocity.y));
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