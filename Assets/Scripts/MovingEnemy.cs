using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingEnemy : Enemy
{
    [SerializeField] private Transform player;
    [SerializeField] private PathType pathType = PathType.CatmullRom;
    public Animator _animator;
    [SerializeField] private List<Transform> pathVal = new();
    [SerializeField] private VisionCone visionCone;
    [SerializeField] private TextMeshPro Txt;
    public int levelCount;

    private void Start()
    {
        Movement();
        LevelSystem(levelCount, Txt);
        visionCone.OnVisionHit += FieldOfView;
    }

    public override void FieldOfView() => Attack(_animator);
    public override void Die(Animator animator)
    {
        base.Die(_animator);
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


}
