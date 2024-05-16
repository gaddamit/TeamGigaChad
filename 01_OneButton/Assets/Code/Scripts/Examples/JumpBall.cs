using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
/// <summary>
/// JumpBall implements IButtonlistener, an interface, which means that it has to implement those functions
/// </summary>
public class JumpBall : MonoBehaviour, IButtonListener
{
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float maxHeight = 5f;
    [SerializeField] private float jumpSpeedIncrease = 1f;
    private Rigidbody2D _rb;
    private ButtonInfo _currentButton;
    
    private PlayerInputs inputObject;
    private bool _isJumping = false;
    [SerializeField]
    private float _jumpDistance = 1f;
    
    enum State
    {
        Forwards,
        Upwards,
        Downwards,
    }    
    private State _state = State.Forwards;
    void Awake()
    {
        _currentButton.CurrentState = ButtonState.Released;
        _rb = GetComponent<Rigidbody2D>();
        var inputObject = FindObjectOfType<PlayerInputs>();
        inputObject.RegisterListener(this);
        _rb.velocity = new Vector2(0, -jumpForce);
    }

    private float _startJumpCounter = 5;
    private void Start()
    {
        InvokeRepeating("StartJump", 2, 1);
    }

    private void StartJump()
    {
        _startJumpCounter--;
        transform.DOJump(transform.position, 1, 1, 1);
        if(_startJumpCounter == 0)
        {
            CancelInvoke("StartJump");
            InvokeRepeating("JumpForward", 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void JumpForward()
    {

        Vector3 direction = Vector3.right;
        if(_state == State.Upwards)
        {
            direction += Vector3.up;
        }
        else if(_state == State.Downwards)
        {
            direction += -Vector3.up;
        }

        transform.DOJump(transform.position + direction * _jumpDistance, 1, 1, 0.5f);
    }

    private void FixedUpdate()
    {
        if (_currentButton.CurrentState == ButtonState.Pressed)
        {
            switch(_state)
            {
                case State.Forwards:
                    _state = State.Upwards;
                    break;
                case State.Upwards:
                    _state = State.Downwards;
                    break;
                case State.Downwards:
                    _state = State.Forwards;
                    break;
            }
        }
    }

    public void ButtonHeld(ButtonInfo heldInfo)
    {
        if(this.transform.position.y < maxHeight)
            _rb.velocity = new Vector2(0, _rb.velocity.y + jumpSpeedIncrease * Time.fixedDeltaTime);
        else 
            _rb.velocity = new Vector2(0, 0);
        _currentButton = heldInfo;
    }

    public void ButtonPressed(ButtonInfo pressedInfo)
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y + jumpForce);
        _currentButton = pressedInfo;
    }

    public void ButtonReleased(ButtonInfo releasedInfo)
    {
        _rb.velocity = new Vector2(0, -jumpForce);
        _currentButton = releasedInfo;
    }
}
