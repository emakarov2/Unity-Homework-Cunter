using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private int _count = 0;
    private bool _isEnabled = false;
    private Coroutine _countingCoroutine;   

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

    private IEnumerator CountHalfsSecond()
    {
        while (_isEnabled)
        {
            yield return new WaitForSeconds(0.5f);
            AddOneToCounter();
            DisplayResult();
        }
    }

    private void AddOneToCounter()
    {
        _count++;

        Debug.Log("Счётчик: " + _count);
    }

    private void DisplayResult()
    {
        _text.text = _count.ToString("");

        Debug.Log("Результат " + _count + " выведен на экран");
    }
}
