using System.Collections;
using UnityEngine;


public class PlaneScript : MonoBehaviour
{
    [SerializeField] private GameObject FireLocation;
    private Vector3 loc;
    [SerializeField] private GameObject projectile;
    private GameObject burst1;
    private GameObject burst2;
    private GameObject burst3;

    float burstVariance;
    public float maxSpeed;
    public bool isAttacking;
    public bool moveLeft;
    public bool moveRight;
    public bool moveUp;
    public bool moveDown;
    public int ammo;
    public int maxAmmo;
    public int reloadAmount = 2;
    public int score;
    private bool isFacingRight;
    float horizontal;

    public Rigidbody2D planeRB;
   

    private Rigidbody2D burst1RB;
    private Rigidbody2D burst2RB;
    private Rigidbody2D burst3RB;

    [SerializeField] private int thrust;

    private bool isWaterEntered = false;
    [SerializeField] private float delayWaterRefill = 2.0f;
    [SerializeField] private GameObject waterMeter;

    private bool allowInput = false;
    [SerializeField] private float inputDelay = 2;

    [SerializeField] private AudioSource[] _sfx;

    // Start is called before the first frame update
    void Start()
    {
        planeRB = GetComponent<Rigidbody2D>();
        planeRB.gravityScale = 0;
        planeRB.drag = 0.7f;
        
        // Animate plane to move right and delay user input
        planeRB.AddForce(this.transform.right * 50 * 3);
        Invoke("EnableInput", inputDelay);
    }

    private void EnableInput()
    {
        allowInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        horizontal = planeRB.velocity.x;
        if (!isFacingRight && horizontal < 0f)
            Flip();
        else if (isFacingRight && horizontal > 0f) Flip();
    }

    // Keyboard input handling
    private void HandleInput()
    {
        if(!allowInput)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!isAttacking && ammo >=1)
            {
                StartCoroutine(gunBurstDelay());
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDown = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveUp = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveRight = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveDown = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveUp = false;
        }
    }

    // Flip the plane when changing direction
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        var localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    private void FixedUpdate()
    {
        if (moveLeft && -planeRB.velocity.x < maxSpeed)
        {
            planeRB.AddForce(this.transform.right * -thrust * 3);
        }
        if (moveRight && planeRB.velocity.x < maxSpeed)
        {
            planeRB.AddForce(this.transform.right * thrust * 3);
        }
        if (moveDown && -planeRB.velocity.y < maxSpeed)
        {
            planeRB.AddForce(this.transform.up * -thrust * 3);
        }
        if (moveUp && planeRB.velocity.y < maxSpeed)
        {
            planeRB.AddForce(this.transform.up * thrust * 3);
        }
    }

    // Fire burst of 3 bullets
    IEnumerator gunBurstDelay()
    {
        isAttacking = true;
        burstVariance = Random.Range(0.9F, 1.1F);
        burst1 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst1RB = burst1.GetComponent<Rigidbody2D>();
        burst1RB.AddForce(transform.right *burstVariance * (planeRB.velocity.x ) *2, ForceMode2D.Impulse);
        burst1RB.AddForce(-transform.up   * burstVariance  , ForceMode2D.Impulse);


        yield return new WaitForSeconds(.05f);
        burstVariance = Random.Range(0.9F, 1.1F);

        burst2 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst2RB = burst2.GetComponent<Rigidbody2D>();
        burst2RB.AddForce(transform.right * burstVariance * (planeRB.velocity.x ) * 2, ForceMode2D.Impulse);
        burst2RB.AddForce(-transform.up  * burstVariance  , ForceMode2D.Impulse);


        yield return new WaitForSeconds(0.05f);
        burstVariance = Random.Range(0.9F, 1.1F);

        burst3 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst3RB = burst3.GetComponent<Rigidbody2D>();
        burst3RB.AddForce(transform.right  * burstVariance * (planeRB.velocity.x ) * 2, ForceMode2D.Impulse);
        burst3RB.AddForce(-transform.up * burstVariance , ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.05f);
        burstVariance = Random.Range(0.9F, 1.1F);

        burst3 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst3RB = burst3.GetComponent<Rigidbody2D>();
        burst3RB.AddForce(transform.right  * burstVariance *( planeRB.velocity.x) * 2 , ForceMode2D.Impulse);
        burst3RB.AddForce(-transform.up   * burstVariance , ForceMode2D.Impulse);
        isAttacking = false;
        ammo--;

        UpdateWaterMeter();
        yield return null;
    }

    private void UpdateWaterMeter()
    {
        SpriteRenderer waterSprite = waterMeter.GetComponent<SpriteRenderer>();
        waterMeter.transform.localScale = new Vector3(1, ammo / (float)maxAmmo, 1);
    }

    public void ReloadAmmo()
    {
        ammo = Mathf.Clamp(ammo + reloadAmount, 0, maxAmmo);
        UpdateWaterMeter();

        if(ammo < maxAmmo)
        {
            if(!_sfx[0].isPlaying)
            {
                _sfx[0].Play();
            }
        }
        else
        {
            _sfx[0].Stop();
        }
    }

    public void StopReloadAmmo()
    {
        _sfx[0].Stop();
    }
}
