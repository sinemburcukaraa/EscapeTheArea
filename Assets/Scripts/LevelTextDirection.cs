using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTextDirection : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
        transform.LookAt(cam.transform);
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
    }
}
