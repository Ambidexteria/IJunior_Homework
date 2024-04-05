using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _movementTime;

    private Vector3 _startPosition;
    private float _actualTime;

    private void Start()
    {
        _startPosition = transform.position;
        _actualTime = _movementTime;
    }

    private void Update()
    {
        if (_actualTime <= 0)
        {
            transform.position = _startPosition;
            _actualTime = _movementTime;
        }

        Move();

        _actualTime -= Time.deltaTime;
    }

    private void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
}
