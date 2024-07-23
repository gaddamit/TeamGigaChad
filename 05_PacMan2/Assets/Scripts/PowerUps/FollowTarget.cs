using UnityEngine;
using DG.Tweening;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    private Tween _tween;
    public void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            targetPosition.y += 1.0f;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f);
        }
    }
}
