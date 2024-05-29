using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerControl : MonoBehaviour
{
    public event Action<PlayerController> OnPlayerEnterTrigger;
    public event Action<Enemy> OnAnimalEnterTrigger;

    public UnityEvent OnPlayerEnterEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            OnPlayerEnterTrigger?.Invoke(player);
            OnPlayerEnterEvent?.Invoke();
        }

        if (other.TryGetComponent(out Enemy animal))
        {
            OnAnimalEnterTrigger?.Invoke(animal);
        }
    }
}
