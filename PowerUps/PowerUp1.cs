using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
    public float sizebuff = 1.1f;
    public float speedbuff = 2f;
    public float duration = 10f;    
    

    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)  /* other = Player */
    {
        if (other.CompareTag("Player"))            /* when player's tag collides with the denpop, trigger the effect */
        {
           StartCoroutine( Pickup(other) );      /* Declares Pickup1 as a function */
        }
    }
    IEnumerator Pickup(Collider2D player)
    { 
        // Particle effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // Add effect
        player.transform.localScale *= sizebuff;            /* Size Buff to indicate change to player */
        PlayerStats stats = player.GetComponent<PlayerStats>();             /* Retrieves player's speed stat from the Player Stats script */
        stats.MoveSpeed *= speedbuff;               /* Speed buff to player */

        /* Disable graphics and box collider to incapcitate the object */   
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // Wait out an interval of time
        yield return new WaitForSeconds (duration);

        // Undo effect
        stats.MoveSpeed /= speedbuff;

        // Remove from field
        Destroy(gameObject);



    }
}

