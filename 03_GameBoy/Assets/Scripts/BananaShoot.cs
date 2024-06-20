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

    public void ShootProjectile()
    {   if(ammo <= 0)
            return;

        ammo--;
        Vector3 playerPosition = _playerController.transform.position;
        Debug.Log("Player position: " + playerPosition);
        Vector3 target = new Vector3(playerPosition.x - 1, playerPosition.y, playerPosition.z);
        GameObject projectile = Instantiate(BananaPrefab, transform.position, Quaternion.identity);
        projectile.transform.DOLocalMove(target, 2).SetEase(Ease.OutCubic).SetLoops(2, LoopType.Yoyo).OnComplete(() => GroundProjectile(projectile)); ;
    }

    public void GroundProjectile(GameObject projectile)
    {
        projectile.GetComponent<BananaProjectile>().isGrounded = true;
    }
}
