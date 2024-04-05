using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime, Space.World);
    }
}
