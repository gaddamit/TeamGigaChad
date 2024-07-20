using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GhostWobble : MonoBehaviour
{
    [SerializeField]
    private bool isMovingRight = true;
    [SerializeField]
    private float _speed = 2;
	public GameObject Ghost1;
	public GameObject Ghost2;
	public GameObject Ghost3;
	public GameObject Ghost4;

    // Start is called before the first frame update
    void Start()
    {
        float z = transform.localPosition.z;
        transform.DOLocalMove(new Vector3(isMovingRight ? 3 : -3, 2, z), _speed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        InvokeRepeating("RotateGhost", 0, _speed);
    }

    private void RotateGhost()
    {
        if (isMovingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            isMovingRight = false;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, -90, 0);
            isMovingRight = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.OnDeath();
        }
    }
}
