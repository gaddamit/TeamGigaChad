using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// JumpBall implements IButtonlistener, an interface, which means that it has to implement those functions
/// </summary>
public class JumpBall : MonoBehaviour
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
    
    [SerializeField]
    private PauseMenu _pauseMenu;
    enum State
    {
        Forwards,
        Upwards,
        Downwards,
    }

    private bool _inputEnabled = true;
    private State _state = State.Forwards;

    private int _buttonPressCounter = 0;
    private int _yLimit = 0;
    private bool _isDead = false;
    private bool _isComplete = false;
    private int _isHittingObstacle = 0;

    [SerializeField]
    private float _startJumpDelay = 4;
    [SerializeField]
    private float _startJumpCounter = 4;

    [SerializeField]
    private AudioSource[] _backgroundMusic;
    void Awake()
    {
        _currentButton.CurrentState = ButtonState.Released;
        _rb = GetComponent<Rigidbody2D>();
        
        var inputObject = FindObjectOfType<PlayerInputs>();
        _rb.velocity = new Vector2(0, -jumpForce);


        // Setup Background Music
        _backgroundMusic = new AudioSource[2];
        _backgroundMusic[0] = GameObject.Find("Audios/BackgroundAudio").GetComponent<AudioSource>();
        _backgroundMusic[1] = GameObject.Find("Audios/CompleteAudio").GetComponent<AudioSource>();
    }

    // Starting Position
    private void Start()
    {
        InvokeRepeating("StartJump", _startJumpDelay, 1);
    }

    // Animate a few jumps
    private void StartJump()
    {
        _startJumpCounter--;
        transform.DOJump(transform.position, 1, 1, 1);

        if(_startJumpCounter == 0)
        {
            _inputEnabled = true;

            CancelInvoke("StartJump");
            InvokeRepeating("JumpForward", 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputEnabled && Input.GetKeyDown(KeyCode.Space))
        {
            _buttonPressCounter++;
        }
    }

    // Make the character jump forward
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

        float scaleX = Random.Range(0, 2) == 0 ? 1 : -1;
        float scaleY = Random.Range(0, 2) == 0 ? 1 : -1;

        transform.localScale = new Vector3(transform.localScale.x * scaleX, transform.localScale.y * scaleY, transform.localScale.z);
        transform.DOJump(transform.position + direction * _jumpDistance, 1, 1, 0.5f).onComplete += ConsumeInput;
    }

    // Check for inputs to change the direction
    // Also check if player is hitting any obstacle
    private void ConsumeInput()
    {
        if(_isHittingObstacle != 0 && !_pauseMenu.isActiveAndEnabled)
        {
            _isDead = true;
            _pauseMenu.Pause(true);
            CancelInvoke("JumpForward");
            return;
        }

        _state = State.Forwards;
        
        if(_buttonPressCounter > 0)
        {
            if(_buttonPressCounter % 2 == 0)
            {
                _state = State.Upwards;
                _yLimit++;
            }
            else
            {
                _state = State.Downwards;
                _yLimit--;
            }
        }

        if(_yLimit < -3 || _yLimit > 4)
        {
            _state = State.Forwards;
        }

        _buttonPressCounter = 0;
    }

    // Check for collisions and update counter if player is hitting any obstacle
    // The isHittingObstacle should be 0 before the next jump or else the player is standing on an obstacle
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_isDead || _isComplete)
        {
            return;
        }

        if(other.CompareTag("Crab"))
        {
            _isHittingObstacle++;
        }

        if(other.CompareTag("Rock"))
        {
            _isHittingObstacle++;
        }

        if(other.CompareTag("FinishLine"))
        {
            _inputEnabled = false;
            _isComplete = true;

            // Start level complete sequence
            Invoke("PlayLevelCompleteMusic", 1);
            Invoke("LoadNextLevel", 4);
        }
    }

    // Check for exit collisions
    private void OnTriggerExit2D(Collider2D other)
    {
        if(_isDead || _isComplete)
        {
            return;
        }

        if(other.CompareTag("Crab"))
        {
            _isHittingObstacle--;
        }

        if(other.CompareTag("Rock"))
        {
            _isHittingObstacle--;
        }
    }

    // Play level complete music and stop background music
    private void PlayLevelCompleteMusic()
    {
        if(_backgroundMusic[0])
        {
            _backgroundMusic[0].Stop();
        }

        if(_backgroundMusic[1])
        {
            _backgroundMusic[1].Play();
        }
    }

    // Move to the next level, if there is no next level, go to the main menu
    private void LoadNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        string name = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( index );
        if(string.IsNullOrEmpty(name))
        {
            Initiate.Fade("MainMenu", Color.black, 1);
        }
        else
        {
            Initiate.Fade(name, Color.black, 1);
        }
    }
}
