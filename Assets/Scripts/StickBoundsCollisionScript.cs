using System.Collections;
using System.Collections.Generic;
using Assets.StaticData;
using UnityEngine;

public class StickBoundsCollisionScript : MonoBehaviour
{
    private CircleCollider2D _collider;
    
    [SerializeField]
    Transform _leftBorder;

    [SerializeField]
    Transform _rightBorder;

    [SerializeField]
    Transform _topBorder;

    [SerializeField]
    Transform _bottomBorder;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var target = transform.position;
        float stickHalfSize = _collider.bounds.size.x / 2;
        
        target.x = Mathf.Clamp(target.x, _leftBorder.position.x + stickHalfSize, _rightBorder.position.x - stickHalfSize);
        target.y = Mathf.Clamp(target.y, _bottomBorder.position.y + stickHalfSize, _topBorder.position.y - stickHalfSize);

        transform.position = Vector3.MoveTowards(transform.position, target, Game.StickSpeedDistance);
    }
}
