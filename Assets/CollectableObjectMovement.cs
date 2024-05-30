using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectMovement : MonoBehaviour
{
    public float rotationSpeed = -90f;
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
