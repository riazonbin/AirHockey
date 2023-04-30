using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhysicsScript : MonoBehaviour
{
    [SerializeField] private Transform background;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private List<StickMovementScriptWithKeys> keyScripts;

    private readonly int[] _possibleRotations = { 0, 90, 180, 270 };


    private void Start()
    {
        StartCoroutine(ChangePhysics());
    }

    private IEnumerator ChangePhysics()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
            RotateCamera();
        }
    }

    public void RotateCamera()
    {
        var index = Random.Range(0, _possibleRotations.Length);
        var rotationAngle = _possibleRotations[index];
        cameraTransform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        background.localRotation = Quaternion.Euler(0, 0, 90 + rotationAngle);
        keyScripts.ForEach(x => x.Rotate(rotationAngle));
    }
}