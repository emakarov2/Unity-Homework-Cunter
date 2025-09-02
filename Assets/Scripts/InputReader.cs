using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int LeftMouseButtonNumber = 0;

    public event Action LeftMouseButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButtonNumber))
        {
            LeftMouseButtonClicked?.Invoke();
        }
    }
}
