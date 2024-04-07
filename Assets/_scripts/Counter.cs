using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private float _step = 1f;
    [SerializeField] private float _maxValue = 100f;

    private float _count;
    private WaitForSeconds _wait;
    private bool _countActive = false;
    private string _countFormat = "0.00";

    private IEnumerator _countCoroutine;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _counterText.text = _count.ToString(_countFormat);
        _countCoroutine = Count();
    }

    private IEnumerator Count()
    {
        while (_count < _maxValue)
        {
            _count += _step;
            _counterText.text = _count.ToString(_countFormat);

            yield return _wait;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (_countActive)
        {
            _countActive = false;
            StopCoroutine(_countCoroutine);
        }
        else
        {
            _countActive = true;
            StartCoroutine(_countCoroutine);
        }
    }
}
