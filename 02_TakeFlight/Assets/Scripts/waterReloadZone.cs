using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterReloadZone : MonoBehaviour
{
    public GameObject planeGO;
    public PlaneScript plane;
    bool isReloading;
    // Start is called before the first frame update
    void Start()
    {
        PlaneScript plane = planeGO.GetComponent<PlaneScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plane.ammo > 50)
        {
            plane.ammo = 50;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asd");
        if (collision.tag == "Player")
        {
            isReloading = true;
            StartCoroutine(Reloading());
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("asd");
        if (collision.tag == "Player")
        {

            isReloading = false;
        }
    }
    IEnumerator Reloading()
    {
        while (plane.ammo < 52 && isReloading)
        {
            plane.ammo++;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
