using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
public class BlurVision : MonoBehaviour
{
    [SerializeField]
    private bool isMovingRight = true;
    [SerializeField]
    private float _speed = 2;
    [SerializeField]
    private float _blurDuration = 5.0f;
    
    public Image blurImage;
    // Start is called before the first frame update
    void Start()
    {
        float z = transform.localPosition.z;
        transform.DOLocalMove(new Vector3(isMovingRight ? 3 : -3, 2, z), _speed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        InvokeRepeating("RotateGhost", 0, _speed);

        blurImage = GameObject.Find("Canvas/BlurVision").GetComponent<Image>();
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
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            blurImage.DOFade(1, _blurDuration);
            Destroy(transform.gameObject);
        }
    }
}
