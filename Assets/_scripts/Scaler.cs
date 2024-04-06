using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Vector3 _scalingVector = Vector3.one;
    [SerializeField] private float _scalingCycleTime = 5f;

    [Range(0f, 1f)] private float _scalingFactor;

    private Vector3 _startScale;

    private void Start()
    {
        _startScale = transform.localScale;
    }

    private void Update()
    {
        Scale();
    }

    private void Scale()
    {
        _scalingFactor = GetScalingFactor();

        Vector3 offset = _scalingVector * _scalingFactor;
        transform.localScale = _startScale + offset;
    }

    private float GetScalingFactor()
    {
        float scalingFactorDivider = 2f;

        float tau = Mathf.PI * 2;
        float cycles = Time.time / _scalingCycleTime;

        float rawSinWave = Mathf.Sin(cycles * tau);

        return (rawSinWave + 1f) / scalingFactorDivider;
    }
}
