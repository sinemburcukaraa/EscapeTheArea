using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingEnemy : Enemy
{
    [SerializeField] private Transform player;
    [SerializeField] private PathType pathType = PathType.CatmullRom;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Transform> pathVal = new();
    [SerializeField] private VisionCone visionCone;
    [SerializeField] private TextMeshPro Txt;
    public int LevelCount;
    private void Start()
    {
        Movement();
        SetLevelTxt();
        visionCone.OnVisionHit += FieldOfView;
    }
    public void SetLevelTxt()
    {
        levelTxt = Txt;
        LevelSystem(LevelCount);
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
        DOTween.Kill(0);
    }
    public override void Movement()
    {
        if (pathVal.Count == 0)
            return;
        Vector3[] pathPositions = pathVal.ConvertAll(t => t.position).ToArray();

        Tweener movement = player.transform.DOPath(pathPositions, 35, pathType)
            .SetOptions(true)
            .SetLookAt(0.01f)
            .SetLoops(-1)
            .SetId(0);

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
    public override void LevelSystem(int levelCount)
    {
        base.LevelSystem(levelCount);
    }

    public override void FieldOfView()
    {
        Attack();
    }
}
