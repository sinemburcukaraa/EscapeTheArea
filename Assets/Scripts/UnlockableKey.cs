using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockableKey : MonoBehaviour, ICollectable
{
    [SerializeField] private Color color;
    private UnlockManager unlockManager;
    [SerializeField] private Image keyIcon;
    [SerializeField] private int id;
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = color;
        unlockManager = UnlockManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ICollectable collectable = this as ICollectable;
            collectable?.Collect();
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
