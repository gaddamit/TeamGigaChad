using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    public UnityEvent onCollect;
    private void Awake()
    {
        if (onCollect == null)
        {
            onCollect = new UnityEvent();

        }

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            onCollect.AddListener(gameManager.CollectableCollected);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}
