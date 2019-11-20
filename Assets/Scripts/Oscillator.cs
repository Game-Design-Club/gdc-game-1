using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    [Range(0, 1)] [SerializeField] float movementFactor;
    Vector3 startingPos;


    void Start()
    {
        startingPos = transform.position;
    }


    void Update()
    {
        float cycles = Time.time / period; //grows continually from 0

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
