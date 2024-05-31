using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class RotatingEnemy : Enemy
{
    [SerializeField] private VisionCone visionCone;
    public Animator _animator;
    public int levelCount;
    [SerializeField] private TextMeshPro Txt;
    public bool control;

    public float rotationAngle = 180f; 
    public float rotationDuration = 1f; 
    public float waitTime; 
    private void Start()
    {
        visionCone.OnVisionHit += FieldOfView;
        Movement();
        LevelSystem(levelCount,Txt);
    }
    public override void FieldOfView() => Attack(_animator);
    public override void Die(Animator animator) => base.Die(_animator);
    public override void Movement()
    {
        Time.timeScale = 1f;
        control = true;
        StartCoroutine(RotateEnemy());
    }
    private IEnumerator RotateEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            yield return transform.DORotate(new Vector3(0, transform.eulerAngles.y + rotationAngle, 0), rotationDuration).WaitForCompletion();
        }
    }

}

