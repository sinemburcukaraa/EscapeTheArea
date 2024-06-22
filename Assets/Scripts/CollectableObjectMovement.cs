using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = -90f;
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
