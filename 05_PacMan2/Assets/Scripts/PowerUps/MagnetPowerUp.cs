using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerUp : MonoBehaviour, IPowerUp
{
    public static event MagnetPowerUpEvent OnMagnetPowerupCollected;
    public delegate void MagnetPowerUpEvent(IPowerUp powerUp);

    [SerializeField] private AudioClip magnetSound;
    [SerializeField] private float magnetDuration = 3f;
    
    public void Collect()
    {
        Debug.Log("MagnetCollected!");
        AudioManager.Instance.PlayLoopedSound(magnetSound, magnetDuration, true);
        Destroy(this.gameObject);
        OnMagnetPowerupCollected?.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}
