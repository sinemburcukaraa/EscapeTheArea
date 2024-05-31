using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class RotatingEnemy : Enemy
{
    [SerializeField] private VisionCone visionCone;
    [SerializeField] private Animator _animator;
    public int levelCount;
    [SerializeField] private TextMeshPro Txt;
    public bool control;

    public float rotationAngle = 180f; // Döndürülecek açý
    public float rotationDuration = 1f; // Dönüþ süresi
    public float waitTime; // Bekleme süresi
    private void Start()
    {
        visionCone.OnVisionHit += FieldOfView;
        Movement();
        SetLevelTxt();
        StartCoroutine(RotateEnemy());
    }

    public void SetLevelTxt()
    {
        levelTxt = Txt;
        LevelSystem(levelCount);
    }

    public override void LevelSystem(int levelCount)
    {
        base.LevelSystem(levelCount);
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

    public override void FieldOfView()
    {
        Attack();
    }

    public override void Movement()
    {
        Time.timeScale = 1f;
        control = true;
    }

    private IEnumerator RotateEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("noliy");
            // Yavaþça 180 derece döndür
            yield return transform.DORotate(new Vector3(0, transform.eulerAngles.y + rotationAngle, 0), rotationDuration).WaitForCompletion();
        }
    }

}

