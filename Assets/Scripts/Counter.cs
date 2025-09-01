using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _count = 0;
    private bool _isEnabled = false;
    private Coroutine _countingCoroutine;

    private WaitForSeconds _waitHalfSecond;
    private float _halfSecondsInSecond = 0.5f;

    public int Count => _count;

    public event Action CountChanged;

    public void SwitchCounter()
    {
        _isEnabled = _isEnabled == false;

        if (_isEnabled)
        {
            _countingCoroutine = StartCoroutine(CountHalfsSecond());

            Debug.Log("Счётчик запущен.");
        }
        else
        {
            StopCoroutine(_countingCoroutine);

            Debug.Log("Счётчик остановлен. Текущее значение: " + _count);
        }
    }

    private void Awake()
    {
        _waitHalfSecond = new WaitForSeconds(_halfSecondsInSecond);
    }

    private IEnumerator CountHalfsSecond()
    {
        while (_isEnabled)
        {
            yield return _waitHalfSecond;
            AddOneToCounter();
        }
    }

    private void AddOneToCounter()
    {
        _count++;

        CountChanged?.Invoke();

        Debug.Log("Счётчик: " + _count);
    }
}
