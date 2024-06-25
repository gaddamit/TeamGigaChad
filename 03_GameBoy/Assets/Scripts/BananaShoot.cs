using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BananaShoot : MonoBehaviour
{
    public int ammo = 3;
    public GameObject BananaPrefab; 
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShootProjectile(float hInput, float vInput)
    {   
        if(ammo <= 0)
        {
            return;
        }

        ammo--;

        Vector3 playerPosition = _playerController.transform.position;
        Vector3 target = new Vector3(playerPosition.x - 1, playerPosition.y, playerPosition.z);

        if(vInput != 0)
        {
            vInput = vInput < 0 ? -1 : 1;
            target = new Vector3(playerPosition.x, playerPosition.y + vInput, playerPosition.z);
        }
        if(hInput != 0)
        {
            hInput = hInput < 0 ? -1 : 1;
            target = new Vector3(playerPosition.x + hInput, playerPosition.y, playerPosition.z);
        }   

        GameObject projectile = Instantiate(BananaPrefab, transform.position, Quaternion.identity);
        projectile.transform.DOLocalMove(target, 2).SetEase(Ease.OutCubic).SetLoops(2, LoopType.Yoyo).OnComplete(() => GroundProjectile(projectile)); ;
    }

    public void GroundProjectile(GameObject projectile)
    {
        projectile.GetComponent<BananaProjectile>().isGrounded = true;
    }
}
