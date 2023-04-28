using System.Collections;
using System.Collections.Generic;
using Assets.StaticData;
using UnityEngine;

public class StickMovementTrackerScript : MonoBehaviour
{
    Vector3 previousPosition;
    Vector3 lastMoveDirection;
    public int multiplier = 1;

    private void Start()
    {
        previousPosition = transform.position;
        lastMoveDirection = Vector3.zero;
    }

    private void Update()
    {
        if (transform.position != previousPosition)
        {
            lastMoveDirection = (transform.position - previousPosition).normalized;
            previousPosition = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Puck"))
        {
            // var a = new Vector2(Random.Range(-250, 250), Random.Range(50, 250) * multiplier);
            // col.gameObject.GetComponent<Rigidbody2D>().AddForce(a);
            // Debug.Log(a);
        }
    }
}