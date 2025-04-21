using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    public static LoopManager instance;
    public float loopLengthInSeconds = 5.053f; // Duración del loop en segundos

    public delegate void OnLoopBeat();
    public event OnLoopBeat OnLoop;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // Llama al primer loop inmediatamente
        OnLoop?.Invoke();

        // Luego comienza el bucle normal
        StartCoroutine(LoopCoroutine());
    }

    private IEnumerator LoopCoroutine()
    {
        while (true)
        {
            OnLoop?.Invoke();
            yield return new WaitForSeconds(loopLengthInSeconds);
        }
    }
}
