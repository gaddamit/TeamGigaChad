using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerUp : PowerUp
{
    [SerializeField] private float _sphereRadius = 1.0f;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            Player player = other.GetComponent<Player>();
            ApplyPowerUp(player);
        }

        base.OnTriggerEnter(other);
    }

    public void ApplyPowerUp(Player player)
    {
        Magnetic magnetic = player.gameObject.GetComponent<Magnetic>();
        if(magnetic != null)
        {
            magnetic.ResetDuration();
        }
        else
        {
            magnetic = player.gameObject.AddComponent<Magnetic>();
            magnetic.Initialize(_duration, _sphereRadius);
        }
    }
}
