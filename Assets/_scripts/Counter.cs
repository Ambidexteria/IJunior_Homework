using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private float _step = 1f;
    [SerializeField] private float _maxValue = 100f;

    private bool _countActive = false;
    private float _count;
    private WaitForSeconds _wait;
    private string _countFormat = "0.00";

    private Coroutine _countCoroutine;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _counterText.text = _count.ToString(_countFormat);
    }

    private void OnMouseUpAsButton()
    {
        if (_countActive)
        {
            _countActive = false;

            if (_countCoroutine != null)
                StopCoroutine(_countCoroutine);
        }
        else
        {
            _countActive = true;
            _countCoroutine = StartCoroutine(Count(_counterText));
        }
    }

    private IEnumerator Count(TextMeshProUGUI text)
    {
        while (_count < _maxValue)
        {
            _count += _step;
            text.text = _count.ToString(_countFormat);

            yield return _wait;
        }
    }
}
