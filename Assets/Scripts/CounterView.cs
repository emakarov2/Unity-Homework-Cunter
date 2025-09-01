using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;


    private void OnEnable()
    {
        _counter.CountChanged += DisplayResult;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= DisplayResult;
    }

    private void DisplayResult()
    {
        int count = _counter.Count;

        _text.text = count.ToString();

        Debug.Log("Результат " + count + " выведен на экран");
    }
}
