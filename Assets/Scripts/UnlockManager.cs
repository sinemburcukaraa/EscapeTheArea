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
public class Keys
{
    public GameObject key;
    public Color color;
    //public Keys(Color color, GameObject key)
    //{
    //    this.color = color;
    //    this.key = key;
    //}
}