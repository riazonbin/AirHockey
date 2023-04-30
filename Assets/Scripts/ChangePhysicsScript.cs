using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhysicsScript : MonoBehaviour
{
    [SerializeField] private Transform background;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private List<StickMovementScriptWithKeys> keyScripts;

    private readonly int[] _possibleRotations = new[] { 0, 90, 180, 270 };


    private void Start()
    {
        StartCoroutine(ChangePhysics());
    }

    private IEnumerator ChangePhysics()
    {
        yield return new WaitForSeconds(1);
        RotateCamera();
    }


    public void RotateCamera()
    {
        var index = 0;
        cameraTransform.rotation = Quaternion.Euler(0, 0, _possibleRotations[index]);
        background.rotation = Quaternion.Euler(0, 0, 90 + _possibleRotations[index]);
        keyScripts.ForEach(x => x.Rotate(_possibleRotations[index]));
    }
}