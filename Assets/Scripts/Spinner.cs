using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private enum RotationDirection
    {
        Left,
        Right
    }
    [SerializeField] private float rotatePower = 20;
    [SerializeField] private RotationDirection rotationDirection;

    private Dictionary<RotationDirection, Vector3> rotationVectors = new()
    {
        { RotationDirection.Left, new Vector3(0, -1, 0) },
        { RotationDirection.Right, new Vector3(0, 1, 0)  }
    };

    void Start()
    {
    }

    void Update()
    {
        RotateObject();
    }

    private void RotateObject()
    {
        Vector3 rotateDirection = rotationVectors[rotationDirection];
        gameObject.transform.Rotate(rotateDirection * (rotatePower * 20 * Time.deltaTime), Space.Self);
    }
        
}
