using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action LeftMouseButtonClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseButtonClicked?.Invoke();
        }
    }
}
