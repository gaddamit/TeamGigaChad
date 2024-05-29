using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    [SerializeField] private GameObject FireLocation;
    private Vector3 loc;
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Rigidbody2D projectileRB;
    [SerializeField] private int thrust;


    // Start is called before the first frame update
    void Start()
    {
        projectileRB = projectile.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

           
                    StartCoroutine(gunBurstDelay());
                
                
            

        }

    }
    IEnumerator gunBurstDelay()
    {
        Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        projectileRB.AddForce(transform.up * thrust, ForceMode2D.Impulse);

        yield return new WaitForSeconds(.1f);
        Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        projectileRB.AddForce(FireLocation.transform.forward * 500);

        yield return new WaitForSeconds(0.1f);
        Instantiate(projectile, FireLocation.transform.position, FireLocation.transform.rotation);
        projectileRB.AddForce(FireLocation.transform.forward * 500);

        yield return null;
    }
}
