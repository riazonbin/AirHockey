using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.StaticData;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangePhysicsScript : MonoBehaviour
{
    [SerializeField] private Transform background;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private List<StickMovementScriptWithKeys> keyScripts;
    [SerializeField] private Transform puck;
    [SerializeField] private List<Transform> sticks;
    private Rigidbody2D _puckRigidBody;
    private List<Rigidbody2D> _stickRigidBodies;
    private bool _objectsMassChanged;
    private bool _coroutineStarted;
    private const float _objectsMassDefaultCooldown = 2;
    private float _objectsMassCurrentCooldown;

    private readonly int[] _possibleRotations = { 0, 90, 180, 270 };

    private Action[] _possiblePhysicsChanges;

    private void Start()
    {
        _puckRigidBody = puck.GetComponent<Rigidbody2D>();
        _stickRigidBodies = sticks.Select(x => x.GetComponent<Rigidbody2D>()).ToList();
        _possiblePhysicsChanges = new Action[] { RotateCamera, RandomPuckScale, RandomSpeedChange, RandomStickScale };
        StartCoroutine(ChangePhysics());
    }

    private void Update()
    {
        if (_objectsMassChanged)
        {
            return;
        }
        if (!_coroutineStarted)
            StartCoroutine(ResetObjectMass());
    }

    private IEnumerator ResetObjectMass()
    {
        _coroutineStarted = true;
        yield return new WaitForSeconds(2);
        var isChangingMass = Random.Range(0, 11);
        Debug.Log(isChangingMass);
        if (isChangingMass > 7 && !_objectsMassChanged)
        {
            ChangeObjectsMass();
            _objectsMassChanged = true;

            yield return new WaitForSeconds(2);
            _puckRigidBody.mass = 1;
            _stickRigidBodies.ForEach(x => x.mass = 1);
            _objectsMassChanged = false;
            Debug.Log("Mass reset");
        }

        _coroutineStarted = false;
    }

    private IEnumerator ChangePhysics()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(Game.TimeSpan.Item1, Game.TimeSpan.Item2));
            var index = Random.Range(0, _possiblePhysicsChanges.Length);
            _possiblePhysicsChanges[index]();
        }
    }

    private void RotateCamera()
    {
        var index = Random.Range(0, _possibleRotations.Length);
        var rotationAngle = _possibleRotations[index];
        cameraTransform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        background.localRotation = Quaternion.Euler(0, 0, 90 + rotationAngle);
        keyScripts.ForEach(x => x.Rotate(rotationAngle));
    }

    private void RandomPuckScale()
    {
        var scale = Random.Range(0.4f, 1f);
        puck.localScale = new Vector3(scale, scale, scale);
    }

    private void RandomStickScale()
    {
        var scale = Random.Range(0.4f, 1f);
        sticks.ForEach(x => x.localScale = new Vector3(scale, scale, scale));
    }

    private void RandomSpeedChange()
    {
        var stickSpeed = Random.Range(20, 40);
        Game.FactStickSpeed = stickSpeed;
        var puckSpeed = Random.Range(15, 25);
        Game.FactPuckSpeed = puckSpeed;
    }

    public void ChangeObjectsMass()
    {
        var index = Random.Range(0, 2);
        if (index == 1)
        {
            // change puck mass
            _puckRigidBody.mass = 100;
            Debug.Log("Puck mass changed");
        }
        else
        {
            _stickRigidBodies.ForEach(x => x.mass = 0.1f);
            Debug.Log("Sticks mass changed");
        }
    }
}