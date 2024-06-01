using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }
}
