using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : Character
{
    private float hInput;
    private float vInput;

    PlayerAnimationController animController;
    public UnityEvent OnDeathEvent;
    private GameManager _gameManager;
    private void Awake()
    {
        animController = GetComponent<PlayerAnimationController>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager.IsGamePaused || _gameManager.IsGameOver)
        {
            return;
        }

        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * vInput * moveSpeed * Time.deltaTime);

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        transform.localScale = new Vector3(1, 1, 1);
        if(hInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        animController.SetParameter("X", hInput);
        animController.SetParameter("Y", vInput);
    }

    public void MoveLeft()
    {
        //hInput = -1;
    }

    public void MoveRight()
    {
        //hInput = 1;
    }

    public void MoveUp()
    {
        //vInput = 1;
    }

    public void MoveDown()
    {
        //vInput = -1;
    }

    public void APressed()
    {
        if(_gameManager.IsGamePaused || _gameManager.IsGameOver)
        {
            return;
        }
        
        BananaShoot bananaShoot = GetComponent<BananaShoot>();
        bananaShoot.ShootProjectile(hInput, vInput);
    }

    public void BPressed()
    {
        Debug.Log("B Pressed");
    }
    
    public void TakeDamage(int damage)
    {
        PlayerLives.lives -= damage;
        if(PlayerLives.lives <= 0)
        {
            Invoke("OnDeath", 0.5f);
        }
    }

    protected override void OnDeath()
    {
        gameObject.SetActive(false);
        OnDeathEvent?.Invoke();
    }
}
