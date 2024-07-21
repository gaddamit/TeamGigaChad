using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    public static event Action OnCollectableCollected;

    [SerializeField] private AudioClip collectableSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnCollectableCollected?.Invoke();
            AudioManager.Instance.PlaySoundEffect(collectableSound);
        }
    }
}
