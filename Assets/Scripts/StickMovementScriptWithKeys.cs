using Assets.StaticData;
using UnityEngine;

public class StickMovementScriptWithKeys : MonoBehaviour
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
        if (Input.GetKey(KeyCode.W))
        {
            target.y += 5;
        }
        if (Input.GetKey(KeyCode.D))
        {
            target.x += 5;
        }
        if (Input.GetKey(KeyCode.A))
        {
            target.x -= 5;
        }
        if (Input.GetKey(KeyCode.S))
        {
            target.y -= 5;
        }
        
        _rigidBody.MovePosition(Vector3.MoveTowards(transform.position, target, Game.StickSpeedDistance));
    }
}
