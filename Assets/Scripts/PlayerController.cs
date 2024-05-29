using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : Characters
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;

    public TriggerControl TriggerControl;
    private void FixedUpdate()
    {
        Movement();
    }

    public override void Attack()
    {
        print("attack");
    }
    public override void Die()
    {
        print("die");
    }
    public override void Movement()
    {
        _rb.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, 0, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _animator.SetBool("Run", true);
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }
        else
            _animator.SetBool("Run", false);
    }

    ///--------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Die();
        }
    }
}
