using UnityEngine;
using DG.Tweening;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed = 60.0f;
    public void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            targetPosition.y += 2.0f;

            float step =  speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }
}
