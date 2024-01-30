using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] bool isDash = false;
    [SerializeField] bool isHealth = false;
    [SerializeField] bool isWin = false;
    [SerializeField] GameObject pickupPrefab = null;
    [SerializeField] GameManager game;
    [SerializeField] AudioSource pickupSfx = null;
    [SerializeField] int points = 10;

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            player.AddPoints(points);
        }
        if (isDash)
        {
            player.GetComponent<PhysicsCharacterController>().dashable = true;
        }
        if (isHealth)
        {
            player.TakeDamage(-5f); //should heal <3
        }
        if (isWin == true)
        {
            game.winGame = true; //should heal <3
            game.winGame = true; //should heal <3
        }
        pickupSfx.Play();
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }
}
