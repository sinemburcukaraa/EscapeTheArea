using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MotionlessEnemy : Enemy
{
    [SerializeField] private VisionCone visionCone;
    [SerializeField] private Animator _animator;
    public int levelCount;
    [SerializeField] private TextMeshPro Txt;
    public void SetLevelTxt()
    {
        levelTxt = Txt;
        LevelSystem(levelCount);
    }
    private void Start()
    {
        visionCone.OnVisionHit += FieldOfView;
    }
    public override void Attack()
    {
        _animator.SetBool("attack", true);
        DOVirtual.DelayedCall(1, () =>
        {
            _animator.SetBool("attack", false);
        });
    }
    public override void Die()
    {
        _animator.SetBool("die", true);
    }
    public override void LevelSystem(int levelCount)
    {
        base.LevelSystem(levelCount);
    }

    public override void FieldOfView()
    {
        Attack();
    }
    public override void Movement()
    {
    }
}
