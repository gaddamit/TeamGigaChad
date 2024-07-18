using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    public static event Action OnPelletCollected;

    [SerializeField] private AudioClip pelletSound;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnPelletCollected?.Invoke();
            AudioManager.Instance.PlaySoundEffect(pelletSound);
        }
    }
}
