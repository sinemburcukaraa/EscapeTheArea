using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    public static UnlockManager instance;
    public List<Keys> Keys = new();
    private void Awake()
    {
        instance = this;
    }
   
}
[Serializable]
public struct Keys
{
    public GameObject key;
    public int id;

    public Keys(int id, GameObject key)
    {
        this.id = id;
        this.key = key;
    }
}