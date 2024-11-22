using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Object = UnityEngine.Object;
using Update = UnityEngine.PlayerLoop.Update;

public class SunflowerZombie : MonoBehaviour, IZombie
{
    public GameObject target;
    public int health = 2;
    
    public void Spawn(Vector3 position)
    {
        GameObject sunflowerZombiePrefab = null;
        
        sunflowerZombiePrefab = Resources.Load<GameObject>("Prefabs/Zombie");
          
        if (sunflowerZombiePrefab != null)
        {
            Object.Instantiate(sunflowerZombiePrefab);
        }
        
        sunflowerZombiePrefab.transform.position = position;
    }

    private void Awake()
    {
        
    }

    void Update()
    {
        Attack();
        Die();
    }

    public void Attack()
    {
        target = GameObject.FindGameObjectWithTag("waypoint");
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,
            Time.deltaTime * 5f);
    }

    public void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            health--;
        }
    }
}
