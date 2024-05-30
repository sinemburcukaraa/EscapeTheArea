using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{
    protected TextMeshPro levelTxt;
    public virtual void LevelSystem(int levelCount)
    {
        if (levelTxt != null)
            levelTxt.text = levelCount.ToString() + " Lvl";
    }
    public abstract void Movement();
    public abstract void Attack();
    public abstract void Die();
}
