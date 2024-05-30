using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlaneScript : MonoBehaviour
{
    [SerializeField] private GameObject FireLocation;
    private Vector3 loc;
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject projectile;
    private GameObject burst1;
    private GameObject burst2;
    private GameObject burst3;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {

           
                    StartCoroutine(gunBurstDelay());
         
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            planeRB.AddForce(this.transform.right * -thrust *3 );

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            planeRB.AddForce(this.transform.right * thrust *3 );

        }


    }
    IEnumerator gunBurstDelay()
    {
        burst1 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst1RB = burst1.GetComponent<Rigidbody2D>();
        burst1RB.AddForce(transform.right * thrust, ForceMode2D.Impulse);
        burst1RB.AddForce(transform.up * -thrust, ForceMode2D.Impulse);


        yield return new WaitForSeconds(.1f);
        burst2 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst2RB = burst2.GetComponent<Rigidbody2D>();
        burst2RB.AddForce(transform.right * thrust, ForceMode2D.Impulse);
        burst2RB.AddForce(transform.up * -thrust, ForceMode2D.Impulse);


        yield return new WaitForSeconds(0.1f);
        burst3 = Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        burst3RB = burst3.GetComponent<Rigidbody2D>();
        burst3RB.AddForce(transform.right * thrust, ForceMode2D.Impulse);
        burst3RB.AddForce(transform.up * -thrust, ForceMode2D.Impulse);

        yield return null;
    }
}
