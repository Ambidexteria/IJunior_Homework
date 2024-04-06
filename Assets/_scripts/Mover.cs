using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _time;

    private Vector3 _startPosition;
    private float _actualTime;

    private void Start()
    {
        _startPosition = transform.position;
        _actualTime = _time;
    }

    private void Update()
    {
        if (_actualTime <= 0)
        {
            transform.position = _startPosition;
            _actualTime = _time;
        }

        Move();

        _actualTime -= Time.deltaTime;
    }

    private void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
}
