using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{
    public abstract void LevelSystem();
    public abstract void Movement();
    public abstract void Attack();
    public abstract void Die();
}
