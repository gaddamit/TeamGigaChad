using UnityEngine;
using DG.Tweening;
using System;

public class Enemy : Character
{
    private Animator anim;
    private Tween _walkTween;
    [SerializeField] private Projectile _projectilePrefab;

    public Action OnEnemyDeath;
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if(anim != null)
        {
            StartWalking();
        }

        _playerController = FindObjectOfType<PlayerController>();
    }

    private void StartWalking()
    {
        anim.SetBool("IsWalking", true);
        _walkTween = gameObject.transform.DOLocalMoveX(1, 15).SetEase(Ease.Linear).OnComplete(StartDestroy);
        
        InvokeRepeating("DoShoot", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartDestroy()
    {
        _playerController.TakeDamage(1);
        OnEnemyDeath?.Invoke();
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

    private void DoShoot()
    {
        anim.SetTrigger("Shoot");
        _walkTween.Pause();
        Invoke("SpawnProjectile", 0.5f);
        Invoke("ResumeWalk", 1);
    }

    private void SpawnProjectile()
    {
        if(_projectilePrefab != null)
        {
            Instantiate(_projectilePrefab, transform.position, _projectilePrefab.transform.rotation);
        }
    }

    private void ResumeWalk()
    {
        _walkTween.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BananaProjectile")
        {
            BananaProjectile projectile = collision.gameObject.GetComponent<BananaProjectile>();
            if(projectile != null)
            {
                OnEnemyDeath?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
