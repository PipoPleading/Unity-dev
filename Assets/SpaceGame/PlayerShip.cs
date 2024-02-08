using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable
{
    [SerializeField] private IntEvent scoreEvent;
    [SerializeField] private Inventory inventory;
    [SerializeField] private IntVariable score;
    [SerializeField] private FloatVariable health;

    [SerializeField] private GameObject hitPrefab;
    [SerializeField] private GameObject destroyPrefab;

    private void Start()
    {
        scoreEvent.Subscribe(AddPoints);
        health.value = 100;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inventory.Use();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            inventory.OnStopUse();
        }
    }

    public void AddPoints(int points)
    {
        score.value += points;
        Debug.Log(score.value);
    }

    public void ApplyDamage(float damage)
    {
        health.value -= damage;
        if (health <= 0) //wtf
        {
            if (destroyPrefab != null)
            {
                Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity); //no active roations applied in the quaternion.identity
            }
            Destroy(gameObject);
        }
        else
        {
            if(hitPrefab != null) 
            {
                Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
            
            }
        }
    }
}