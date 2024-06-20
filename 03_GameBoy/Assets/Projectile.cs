using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.DOLocalMoveX(1, 2.0f).SetEase(Ease.Linear).OnComplete(StartDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartDestroy()
    {
        Destroy(this.gameObject);
    }
}
