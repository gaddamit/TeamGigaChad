using UnityEngine;
using DG.Tweening;

public class Enemy : Character
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if(anim != null)
        {
            StartWalking();
        }
    }

    private void StartWalking()
    {
        anim.SetBool("IsWalking", true);
        gameObject.transform.DOLocalMoveX(1, 15).SetEase(Ease.Linear).OnComplete(StartDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartDestroy()
    {
        base.DestroyObject();
    }

    protected override void OnHit()
    {
        base.OnHit();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        if(anim != null)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsDead", true);
        }
    }
}
