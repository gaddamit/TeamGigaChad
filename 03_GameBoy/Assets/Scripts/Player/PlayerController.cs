using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private float hInput;
    private float vInput;

    PlayerAnimationController animController;

    private void Awake()
    {
        animController = GetComponent<PlayerAnimationController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * vInput * moveSpeed * Time.deltaTime);

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
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
        Debug.Log("A Pressed");
        
        BananaShoot bananaShoot = GetComponent<BananaShoot>();
        bananaShoot.ShootProjectile();
    }

    public void BPressed()
    {
        Debug.Log("B Pressed");
    }
    
}
