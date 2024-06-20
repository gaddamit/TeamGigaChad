using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("Player hit by enemy");
            PlayerLives.lives--;
            if(PlayerLives.lives <= 0)
            {
                PlayerManager.isGameOver = true; 
                gameObject.SetActive(false);
            }
        }
        
        if (collision.transform.tag == "Projectile")
        {
            PlayerLives.lives--;
            if(PlayerLives.lives <= 0)
            {
                PlayerManager.isGameOver = true; 
                gameObject.SetActive(false);
            }
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
