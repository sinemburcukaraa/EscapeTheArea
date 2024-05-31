using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public abstract class Enemy : Characters
{    
    public override void Attack(Animator _animator)
    {
       base.Attack(_animator);
    }  
    public abstract void FieldOfView();
 
}
