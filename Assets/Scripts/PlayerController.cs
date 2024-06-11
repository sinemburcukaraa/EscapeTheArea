using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : Characters
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystick;
    public Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private TextMeshPro Txt;
    public int levelCount;
    public bool canMove = true;

    private void FixedUpdate()
    {
        Movement();
    }
    public void SetLevelTxt()
    {
        LevelSystem(levelCount, Txt);
    }
    public override void Die(Animator animator)
    {
        base.Die(_animator);
        canMove = false;
        GameManager.instance.GameOver();
    }
    public override void Movement()
    {
        if (!canMove)
            return;

        _rb.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, 0, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _animator.SetBool("Run", true);

            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
    }

    // Player Trigger Control
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Attack(_animator);
            CheckAndDie(other);
        }

    }
    public void CheckAndDie(Collider other)
    {
        if (other.GetComponent<MovingEnemy>() != null && CheckLevel(other.GetComponent<MovingEnemy>().levelCount))
        {
            other.GetComponent<MovingEnemy>().Die(other.GetComponent<MovingEnemy>()._animator);
        }
        else if (other.GetComponent<MotionlessEnemy>() != null && CheckLevel(other.GetComponent<MotionlessEnemy>().levelCount))
        {
            other.GetComponent<MotionlessEnemy>().Die(other.GetComponent<MotionlessEnemy>()._animator);
        }
        else if (other.GetComponent<RotatingEnemy>() != null && CheckLevel(other.GetComponent<RotatingEnemy>().levelCount))
        {
            other.GetComponent<RotatingEnemy>().Die(other.GetComponent<RotatingEnemy>()._animator);
        }
        else
        {
            Die(_animator);
        }
    }
    public bool CheckLevel(int enemyLevel)
    {
        bool playerStatus;
        if (levelCount > enemyLevel)
            playerStatus = true;
        else
            playerStatus = false;
        return playerStatus;
    }
   
}
