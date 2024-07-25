using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class RandomJumping : MonoBehaviour
{
    [SerializeField]
    private bool isMovingRight = true;
    [SerializeField]
    private float _speed = 2;
    [SerializeField]
    private float _jumpHeight = 4;

    // Start is called before the first frame update
    void Start()
    {
        float z = transform.localPosition.z;
        InvokeRepeating("Jump", 0, _speed);
    }

    private void Jump()
    {
        int randomX = Random.Range(-1, 2);
        int randomZ = Random.Range(-1, 2);
        transform.DOLocalJump(new Vector3(3 * randomX,2,3 * randomZ), _jumpHeight, 1, _speed).SetEase(Ease.Linear);
        transform.localRotation = Quaternion.Euler(0, Random.Range(0,361), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            Player player = other.GetComponent<Player>();
            player.OnDeath();
        }
    }
}
