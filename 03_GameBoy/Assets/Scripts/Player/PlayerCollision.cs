using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            PlayerController playerController = GetComponent<PlayerController>();
            playerController.TakeDamage(1);
        }

        if(collision.transform.tag == "BananaProjectile")
        {
            BananaProjectile bananaProjectile = collision.gameObject.GetComponent<BananaProjectile>();
            if(bananaProjectile.isGrounded)
            {
                Debug.Log("Player picked up ammo");
                Destroy(collision.gameObject);
                
                BananaShoot bananaShoot = GetComponent<BananaShoot>();
                bananaShoot.ammo++;
            }
        }
    }

 }
