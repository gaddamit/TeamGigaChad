using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent OnPlayerDeath;
    public UnityEvent OnPlayerCollectKey;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && other.GetType() == typeof(CapsuleCollider))
        {
            OnPlayerDeath?.Invoke();
        }
        else if (other.CompareTag("Key"))
        {
            OnPlayerCollectKey?.Invoke();
        }
    }
}
