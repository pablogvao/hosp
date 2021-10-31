using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOscillator : MonoBehaviour
{
    float _timeCounter = 0;

    float _speed;
    float _width;
    float _height;

    void Start()
    {
        _speed = 3f;
        _width = 0.1f;
        _height = 0.1f;
    }

    void Update()
    {
        _timeCounter += Time.deltaTime * _speed;

        float x = Mathf.Cos(_timeCounter) * _width;
        float y = Mathf.Sin(_timeCounter) * _height;

        transform.position += new Vector3(x, y);
    }
}
