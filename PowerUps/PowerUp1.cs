using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
    public float multiplier = 2f;

    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)  /* other = Player */
    {
        if (other.CompareTag("Player"))            /* when player's tag collides with the denpop, trigger the effect */
        {
            Pickup(other);      /* Declares Pickup1 as a function */
        }
    }
    void Pickup(Collider2D player)
    {
        // Add effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // Remove from scene
        player.transform.localScale *= multiplier;

        // Spawn particle effect
        Destroy(gameObject);



    }
}

