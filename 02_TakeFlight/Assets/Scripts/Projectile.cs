using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeLeft = 1f;
    

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if( timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
