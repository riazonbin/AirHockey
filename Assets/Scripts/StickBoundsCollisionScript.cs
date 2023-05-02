using Assets.StaticData;
using UnityEngine;

public class StickBoundsCollisionScript : MonoBehaviour
{
    private CircleCollider2D _collider;

    [SerializeField] public Transform leftBorder;

    [SerializeField] public Transform rightBorder;

    [SerializeField] public Transform topBorder;

    [SerializeField] public Transform bottomBorder;

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

        target.x = Mathf.Clamp(target.x, leftBorder.position.x + stickHalfSize, rightBorder.position.x - stickHalfSize);
        target.y = Mathf.Clamp(target.y, bottomBorder.position.y + stickHalfSize, topBorder.position.y - stickHalfSize);
        transform.position = Vector3.MoveTowards(transform.position, target, Game.FactStickSpeed * Time.deltaTime);
    }
}