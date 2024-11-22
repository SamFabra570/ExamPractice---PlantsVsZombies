using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
    }

    public void Attack()
    {
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
