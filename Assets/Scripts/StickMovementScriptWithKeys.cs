using Assets.StaticData;
using UnityEngine;

public class StickMovementScriptWithKeys : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public bool isArrow;
    private KeyCode[] _defaultKeyCodes;
    private KeyCode[] _keyCodes;

    private void Start()
    {
        _defaultKeyCodes = isArrow
            ? new[] { KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.LeftArrow }
            : new[] { KeyCode.W, KeyCode.D, KeyCode.S, KeyCode.A };
        _keyCodes = new[] { _defaultKeyCodes[0], _defaultKeyCodes[1], _defaultKeyCodes[2], _defaultKeyCodes[3] };
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var target = transform.position;
        if (Input.GetKey(_keyCodes[0]))
        {
            target.y += 5;
        }

        if (Input.GetKey(_keyCodes[1]))
        {
            target.x += 5;
        }

        if (Input.GetKey(_keyCodes[2]))
        {
            target.y -= 5;
        }

        if (Input.GetKey(_keyCodes[3]))
        {
            target.x -= 5;
        }

        _rigidBody.MovePosition(Vector3.MoveTowards(transform.position, target, Game.FactStickSpeed * Time.deltaTime));
    }

    public void Rotate(int angle)
    {
        switch (angle)
        {
            case 90:
                _keyCodes = new[] { _defaultKeyCodes[1], _defaultKeyCodes[2], _defaultKeyCodes[3], _defaultKeyCodes[0] };
                break;
            case 180:
                _keyCodes = new[] { _defaultKeyCodes[2], _defaultKeyCodes[3], _defaultKeyCodes[0], _defaultKeyCodes[1] };
                break;
            case 270:
                _keyCodes = new[] { _defaultKeyCodes[3], _defaultKeyCodes[0], _defaultKeyCodes[1], _defaultKeyCodes[2] };
                break;
            case 0:
                _keyCodes = new[] { _defaultKeyCodes[0], _defaultKeyCodes[1], _defaultKeyCodes[2], _defaultKeyCodes[3] };
                break;
        }
    }
}