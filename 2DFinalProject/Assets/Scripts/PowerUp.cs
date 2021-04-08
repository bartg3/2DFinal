using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //Make sure the game object for the pickup has collision//
    public float multiplier = 1.5f;
    public float duration = 4.0f;
    
    //Optional particaleffect that plays once when picked up, must be created in unity//
    public GameObject pickupEffect;

    void OnTriggerEnter3D(Collider2D other)
    {
        //rename this to whatever the player's tag is//
        if (other.CompareTag("PLayerControl"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //Rename PlayerController inside GetComponent To whatever the player script is called//
        PLayerControl stats = player.GetComponent<PLayerControl>();

        //Rename speed to whatever it is called inside the player script//
        stats.speed *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.speed /= multiplier;

        Destroy(gameObject);
    }
}
