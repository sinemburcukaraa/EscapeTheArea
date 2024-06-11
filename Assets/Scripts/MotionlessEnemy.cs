using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MotionlessEnemy : Enemy
{
    [SerializeField] private VisionCone visionCone;
    public Animator _animator;
    public int levelCount;
    [SerializeField] private TextMeshPro Txt;
    private void Start()
    {
        visionCone.OnVisionHit += FieldOfView;
        LevelSystem(levelCount, Txt);
    }
    public override void Die(Animator animator) => base.Die(_animator);

    public override void FieldOfView() => Attack(_animator);

    public override void Movement()
    {
    }
}
