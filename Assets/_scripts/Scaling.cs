using UnityEngine;

public class Scaling : MonoBehaviour
{
    [SerializeField] private float _scalingSpeed;
    [SerializeField] private float _maxScale;

    private Vector3 _startScale;

    private void Start()
    {
        _startScale = transform.localScale;
    }

    private void Update()
    {
        if (transform.localScale.x > _maxScale)
        {
            transform.localScale = _startScale;
        }

        Scale();
    }

    private void Scale()
    {
        transform.localScale += _scalingSpeed * Time.deltaTime * Vector3.one;
    }
}
