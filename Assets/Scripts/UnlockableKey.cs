using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockableKey : MonoBehaviour, ICollectable
{
    public Color color;
    UnlockManager unlockManager;
    public Image keyIcon;
    public int id;
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = color;
        unlockManager = UnlockManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
    public void Collect()
    {
        Keys newKey = new Keys(id, this.gameObject);
        unlockManager.Keys.Add(newKey);
        keyIcon.gameObject.SetActive(true);
        this.transform.gameObject.SetActive(false);
    }

}
