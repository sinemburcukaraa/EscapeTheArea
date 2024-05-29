using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
    [SerializeField] private Transform player;
    [SerializeField] private PathType pathType = PathType.CatmullRom;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Vector3> pathVal = new();
    //[SerializeField] private int LevelCount;
    [SerializeField] private VisionCone visionCone;

    private void Start()
    {
        Movement();
        visionCone.OnVisionHit += FieldOfView;
    }
    public override void FieldOfView()
    {
        Attack();
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
        _animator.SetBool("run", false);
    }
    public override void Movement()
    {
        if (pathVal.Count == 0)
            return;

        Tweener movement = player.transform.DOPath(pathVal.ToArray(), 35, pathType)
            .SetOptions(true)
            .SetLookAt(0.01f)
            .SetLoops(-1);

        movement.OnWaypointChange(OnWaypointChange);
    }
    private void OnWaypointChange(int waypointIndex)
    {
        StartCoroutine(WaitAtWaypoint(waypointIndex));
    }
    private IEnumerator WaitAtWaypoint(int waypointIndex)
    {
        player.transform.DOPause();
        _animator.SetBool("run", false); 
        yield return new WaitForSeconds(1);
        player.transform.DOPlay();
        _animator.SetBool("run", true);
    }
    public override void LevelSystem()
    {
        throw new System.NotImplementedException();
    }
}
