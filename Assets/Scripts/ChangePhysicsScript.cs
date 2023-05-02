using System;
using System.Collections;
using System.Collections.Generic;
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

    private readonly int[] _possibleRotations = { 0, 90, 180, 270 };

    private Action[] _possiblePhysicsChanges;

    private void Start()
    {
        _possiblePhysicsChanges = new Action[] { RotateCamera };
        StartCoroutine(ChangePhysics());
    }

    private IEnumerator ChangePhysics()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 2));
            var index = Random.Range(0, _possiblePhysicsChanges.Length);
            _possiblePhysicsChanges[index]();
        }
    }

    private void RotateCamera()
    {
        var index = 1;
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
        var scale = Random.Range(0.7f, 1.3f);
        sticks.ForEach(x => x.localScale = new Vector3(scale, scale, scale));
    }

    private void RandomSpeedChange()
    {
        var stickSpeed = Random.Range(20, 40);
        Game.FactStickSpeed = stickSpeed;
        var puckSpeed = Random.Range(15, 25);
        Game.FactPuckSpeed = puckSpeed;
    }
}