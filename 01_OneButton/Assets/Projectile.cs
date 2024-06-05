using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeLeft = 2f;
    // Start is called before the first frame update
    void Start()
    {
        float timeLeft = 200f;
    }

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
