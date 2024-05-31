using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour, ICollectable
{
    public Color color;
    UnlockManager unlockManager;
    public Image keyIcon;
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = color;
        unlockManager = UnlockManager.instance;
    }
    private void OnTriggerEnter(Collider other)//collectable manager scripti aç;
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
    public void Collect()
    {
        //Keys newKey = new Keys(color, this.gameObject); 
        //unlockManager.Keys.Add(this);
        keyIcon.gameObject.SetActive(true);
        this.transform.gameObject.SetActive(false);
    }

}
