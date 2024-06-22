using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKeyTrigger : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField]private GameObject rightDoor;
    [SerializeField]private GameObject leftDoor;
    [SerializeField] private int id;
    private void Start()
    {
        rightDoor.GetComponent<MeshRenderer>().material.color = color;
        leftDoor.GetComponent<MeshRenderer>().material.color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < UnlockManager.instance.Keys.Count; i++)
            {
                if (UnlockManager.instance.Keys[i].id == id)
                {
                    leftDoor.GetComponent<Rigidbody>().isKinematic = false;  
                    rightDoor.GetComponent<Rigidbody>().isKinematic = false;
                    GameManager.instance.LevelCompleted();
                }
            }
        }
    }
}
