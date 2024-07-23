using UnityEngine;
using DG.Tweening;

public class PowerUp : Collectable, IPowerUp
{
    [SerializeField] protected float _duration = 3f;
    
    private void Start()
    {
        StartAnimating();
    }

    private void StartAnimating()
    {
        transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public void ApplyPowerUp()
    {
        throw new System.NotImplementedException();
    }
}
