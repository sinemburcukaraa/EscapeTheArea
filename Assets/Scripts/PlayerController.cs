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
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private TextMeshPro Txt;
    public int levelCount;

    private void FixedUpdate()
    {
        Movement();
    }
    public void SetLevelTxt()
    {
        levelTxt = Txt;
        LevelSystem(levelCount);
    }
    public override void Attack()
    {
        _animator.SetBool("Attack", true);//attack animasyon çalýþacak level kontrol falan
    }
    public override void Die()
    {
        _animator.SetBool("die", true);
        canMove = false;
        GameManager.instance.GameOver();
    }
    public bool canMove = true;
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
    public override void LevelSystem(int levelCount)
    {
        base.LevelSystem(levelCount);
    }



    // Player Trigger Control
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Attack();

            if (other.GetComponent<MovingEnemy>() != null && CheckLevel(other.GetComponent<MovingEnemy>().LevelCount))
            {
                other.GetComponent<MovingEnemy>().Die();

            }  
            else if (other.GetComponent<MotionlessEnemy>() != null && CheckLevel(other.GetComponent<MotionlessEnemy>().levelCount))
            {
                other.GetComponent<MotionlessEnemy>().Die();
            }
            else
            {
                Die();
            }
        }

    }
    public bool playerStatus;
    public bool CheckLevel(int enemyLevel)
    {
        if (levelCount > enemyLevel)
            playerStatus = true;
        else
            playerStatus = false;
        return playerStatus;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _animator.SetBool("Attack", false);
        }
    }
}
