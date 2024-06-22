using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{
    public abstract void Movement();
    public virtual void LevelSystem(int levelCount, TextMeshPro txt)
    {
        if (txt != null)
            txt.text = levelCount.ToString() + " Lvl";
    }
    public virtual void Attack(Animator _animator)
    {
        _animator.SetBool("attack", true);
        DOVirtual.DelayedCall(1, () =>
        {
            _animator.SetBool("attack", false);
        });
    }
    public virtual void Die(Animator _animator)
    {
        _animator.SetBool("die", true);
   
        DOVirtual.DelayedCall(1, () =>
        {
            Destroy(gameObject);
        });
    }
}