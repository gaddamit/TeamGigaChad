using UnityEngine;
using Dreamteck.Forever;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    LaneRunner runner;
    float boost = 0f;
    public static Player instance;
    bool canBoost = true;
    float speed = 0f;
    float startSpeed = 0f;
    public Color regularColor;
    public Color boostColor;
    Material material;
    private Rigidbody rb;
    private bool _isJumping = false;
    
    [SerializeField]
    private float _speedCap = 50;
    [SerializeField]
    private float _speedIncrement = 0.5f;
    private bool _isDead = false;
    private Animator _animator;

    public UnityEvent onDeath;
    public UnityEvent onGameOver;

    private void Awake()
    {
        runner = GetComponent<LaneRunner>();
        startSpeed = speed = runner.followSpeed;
        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    void OnRestart()
    {
        LevelGenerator.instance.Restart();
        runner.followSpeed = speed = startSpeed;
    }

    private void Update()
    {
        if(_isDead)
        {
            return;
        }

        //Lane switching logic
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) runner.lane--;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) runner.lane++;

        //Capture Boost Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            _isJumping = false;
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        runner.followSpeed = speed;
        if(speed == 0f) EndScreen.Open();
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void IncreaseSpeed()
    {
        if(speed < _speedCap)
        {
            SetSpeed(speed + _speedIncrement);
        }
    }

    public void OnDeath()
    {
        if(_isDead)
        {
            return;
        }

        _isDead = true;
        _animator.SetTrigger("Death");
        SetSpeed(0f);
        
        onDeath?.Invoke();
        Invoke("GameOver", 3.0f);
    }

    public void GameOver()
    {
        onGameOver?.Invoke();
    }
}