using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour, ICollectable
{
    public int power;
    public PlayerController playerController;
    public delegate void LevelUpDel();
    public event LevelUpDel levelUp;
    private void Start()
    {
        levelUp += playerController.SetLevelTxt;
        levelUp.Invoke();
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
        playerController.levelCount += power;
        levelUp.Invoke();
        transform.gameObject.SetActive(false);
    }
}
