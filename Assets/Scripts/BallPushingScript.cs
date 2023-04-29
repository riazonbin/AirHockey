using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallPushingScript : MonoBehaviour
{
    private readonly float _pushForce = 500;

    private bool _canPushBlue = true;
    private float _blueTimeRemaining;
    public Text blueCooldownText;

    private bool _canPushRed = true;
    private float _redTimeRemaining;
    public Text redCooldownText;

    public Rigidbody2D ball;

    // Update is called once per frame
    void Update()
    {
        if (!_canPushRed)
        {
            _redTimeRemaining -= Time.deltaTime;
            redCooldownText.text = ((int)_redTimeRemaining).ToString();
        }

        if (!_canPushBlue)
        {
            _blueTimeRemaining -= Time.deltaTime;
            blueCooldownText.text = ((int)_blueTimeRemaining).ToString();
        }

        if (_canPushBlue && Input.GetKeyDown(KeyCode.Space))
        {
            _canPushBlue = false;
            StartCoroutine(SpacebarCooldown());
            var index = Random.Range(0, 2);
            ball.AddForce(new Vector2(index == 1 ? _pushForce : -_pushForce, _pushForce));
            _blueTimeRemaining = 4;
        }

        if (_canPushRed && Input.GetKeyDown(KeyCode.Slash))
        {
            _canPushRed = false;
            StartCoroutine(SpacebarCooldownRed());
            var index = Random.Range(0, 2);
            ball.AddForce(new Vector2(index == 1 ? _pushForce : -_pushForce, -_pushForce));
            _redTimeRemaining = 4;
        }
    }

    IEnumerator SpacebarCooldown()
    {
        yield return new WaitForSeconds(3);
        _canPushBlue = true;
    }

    IEnumerator SpacebarCooldownRed()
    {
        yield return new WaitForSeconds(3);
        _canPushRed = true;
    }
}