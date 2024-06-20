using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaProjectile : MonoBehaviour
{
    public bool isGrounded = false;
    public float moveSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 360 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
        }
    }
}
