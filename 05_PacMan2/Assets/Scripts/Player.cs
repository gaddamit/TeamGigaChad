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
    private bool isJumping = false;

    [SerializeField] private float magnetPullSpeed = 1.75f;
    [SerializeField] private float threshold = 1f;
    
    [SerializeField]
    private float _speedCap = 50;
    [SerializeField]
    private float _speedIncrement = 0.5f;
    private bool isDead = false;
    private Animator _animator;


    public UnityEvent onDeath;
    public UnityEvent onCleanup;

    private void Awake()
    {
        runner = GetComponent<LaneRunner>();
        startSpeed = speed = runner.followSpeed;
        instance = this;
        rb = GetComponent<Rigidbody>();

        MagnetPowerUp.OnMagnetPowerupCollected += PowerUpCollected;
    }

    void OnRestart()
    {
        LevelGenerator.instance.Restart();
        runner.followSpeed = speed = startSpeed;
    }

    private void Update()
    {
        if(isDead)
        {
            return;
        }

        //Lane switching logic
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) runner.lane--;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) runner.lane++;

        //Capture Boost Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isJumping = false;
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
        if(isDead)
        {
            return;
        }

        isDead = true;
        _animator.SetTrigger("Death");
        SetSpeed(0f);
        
        onDeath?.Invoke();
        Invoke("CleanUp", 3.0f);
    }

    public void CleanUp()
    {
        onCleanup?.Invoke();
    }

    private void PowerUpCollected(IPowerUp powerUp)
    {
        
        if (powerUp is MagnetPowerUp)
        {
            GameObject[] pellets = GameObject.FindGameObjectsWithTag("Pellet");
            
            Debug.Log($"there are {pellets.Length} Pellets");

            foreach (GameObject pellet in pellets)
            {
                if (Vector3.Distance(pellet.transform.position, transform.position) > threshold)
                    pellet.transform.position = transform.position;
                ;
            }
        }
    }
}