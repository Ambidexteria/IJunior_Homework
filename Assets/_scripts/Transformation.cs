using UnityEngine;

public class Transformation : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _scalingSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _time;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Vector3 _startScale;

    private float _actualTime;

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _startScale = transform.localScale;

        _actualTime = _time;
    }

    private void Update()
    {
        if(_actualTime <= 0)
        {
            _actualTime = _time;
            ReturnToStart();
        }

        Move();
        Rotate();
        Scale();

        _actualTime -= Time.deltaTime;
    }

    private void ReturnToStart()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        transform.localScale = _startScale;
    }

    private void Move()
    {
        transform.Translate(_movementSpeed * Time.deltaTime * Vector3.forward);
    }

    private void Rotate()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up, Space.World);
    }

    private void Scale()
    {
        transform.localScale += _scalingSpeed * Time.deltaTime * Vector3.one; 
    }
}
