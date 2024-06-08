using System.Collections;
using UnityEngine;


public class PlaneScript : MonoBehaviour
{
    [SerializeField] private GameObject FireLocation;
    private Vector3 loc;
    [SerializeField] private GameObject Gun;
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

    public Rigidbody2D planeRB;
   

    private Rigidbody2D burst1RB;
    private Rigidbody2D burst2RB;
    private Rigidbody2D burst3RB;

    [SerializeField] private int thrust;


    // Start is called before the first frame update
    void Start()
    {
        planeRB = GetComponent<Rigidbody2D>();
        planeRB.gravityScale = 0;
        planeRB.drag = 1;
        
        
    }

    // Update is called once per frame
    void Update()
    {
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
    IEnumerator gunBurstDelay()
    {
        isAttacking = true;
        burstVariance = Random.Range(0.9F, 1.1F);
        burst1 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst1RB = burst1.GetComponent<Rigidbody2D>();
        burst1RB.AddForce(transform.right * thrust *burstVariance , ForceMode2D.Impulse);
        burst1RB.AddForce(transform.up * -thrust * burstVariance  , ForceMode2D.Impulse);


        yield return new WaitForSeconds(.05f);
        burstVariance = Random.Range(0.9F, 1.1F);

        burst2 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst2RB = burst2.GetComponent<Rigidbody2D>();
        burst2RB.AddForce(transform.right * thrust* burstVariance , ForceMode2D.Impulse);
        burst2RB.AddForce(transform.up * -thrust * burstVariance  , ForceMode2D.Impulse);


        yield return new WaitForSeconds(0.05f);
        burstVariance = Random.Range(0.9F, 1.1F);

        burst3 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst3RB = burst3.GetComponent<Rigidbody2D>();
        burst3RB.AddForce(transform.right * thrust * burstVariance , ForceMode2D.Impulse);
        burst3RB.AddForce(transform.up * -thrust * burstVariance , ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.05f);
        burstVariance = Random.Range(0.9F, 1.1F);

        burst3 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst3RB = burst3.GetComponent<Rigidbody2D>();
        burst3RB.AddForce(transform.right * thrust * burstVariance, ForceMode2D.Impulse);
        burst3RB.AddForce(transform.up * -thrust * burstVariance , ForceMode2D.Impulse);
        isAttacking = false;
        ammo--;
        yield return null;
    }
}
