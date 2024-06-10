using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterReloadZone : MonoBehaviour
{
    private bool isReloading = false;
    [SerializeField] private PlaneScript plane;
    [SerializeField] private float delayWaterRefill = 0.2f;
    [SerializeField] private float delayWaterZoneContact = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReloading = true;

            StartCoroutine(Reloading());
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReloading = false;
            plane.StopReloadAmmo();
            StopCoroutine(Reloading());
        }
    }
    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(delayWaterZoneContact);
        while (plane.ammo < plane.maxAmmo && isReloading)
        {
            plane.ReloadAmmo();
            yield return new WaitForSeconds(delayWaterRefill);
        }
    }
}
