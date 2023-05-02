using UnityEngine;

public class RestoreObjectsPositionScript : MonoBehaviour
{
    [SerializeField] private Transform redBall;

    [SerializeField] private Transform blueBall;

    [SerializeField] private Transform puck;

    [SerializeField] private Transform bluePos;

    [SerializeField] private Transform redPos;

    public void RestoreObjectsPositions()
    {
        redBall.position = redPos.position;
        blueBall.position = bluePos.position;
        puck.position = new Vector2(0, 0);
        puck.GetComponent<Rigidbody2D>().AddForce(new Vector2(1600, 0));
        puck.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}