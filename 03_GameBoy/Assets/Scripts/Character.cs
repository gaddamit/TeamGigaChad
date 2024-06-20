using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private bool isAlive = true;
    [SerializeField] protected float moveSpeed = 1;
    [SerializeField] private float health = 5;


    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    protected virtual void OnHit()
    {
        health--;
        if(health <= 0)
        {
            isAlive = false;
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        
    }

    protected void DestroyObject()
    {
        Destroy(gameObject);
    }
}
