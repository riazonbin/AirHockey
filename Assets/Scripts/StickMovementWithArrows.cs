using Assets.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMovementWithArrows : MonoBehaviour
{
    [SerializeField]
    Transform _leftBorder;

    [SerializeField]
    Transform _rightBorder;

    [SerializeField]
    Transform _topBorder;

    [SerializeField]
    Transform _bottomBorder;

    // Update is called once per frame
    void Update()
    {
        var target = transform.position;

        float stickHalfSize = GetComponent<CircleCollider2D>().bounds.size.x / 2;


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

        target.x = Mathf.Clamp(target.x, _leftBorder.position.x + stickHalfSize, _rightBorder.position.x - stickHalfSize);
        target.y = Mathf.Clamp(target.y, _bottomBorder.position.y + stickHalfSize, _topBorder.position.y - stickHalfSize);

        transform.position = Vector3.MoveTowards(transform.position, target, Game.StickSpeedDistance);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Puck"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000));
        }
    }
}
