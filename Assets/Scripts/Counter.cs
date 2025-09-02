using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private int _count = 0;
    private bool _isEnabled = false;
    private float _delayInSeconds = 0.5f;

    private Coroutine _countingCoroutine;
    private WaitForSeconds _delay;

    public int Count => _count;

    public event Action CountChanged;

    private void Awake()
    {
        _delay = new WaitForSeconds(_delayInSeconds);
    }

    private void OnEnable()
    {
        _inputReader.LeftMouseButtonClicked += SwitchCounter;
    }

    private void OnDisable()
    {
        _inputReader.LeftMouseButtonClicked -= SwitchCounter;
    }

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
            if (_countingCoroutine != null)
            {
                StopCoroutine(_countingCoroutine);

                _countingCoroutine = null;
            }

            Debug.Log("Счётчик остановлен. Текущее значение: " + _count);
        }
    }

    private IEnumerator CountHalfsSecond()
    {
        while (_isEnabled)
        {
            yield return _delay;
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
