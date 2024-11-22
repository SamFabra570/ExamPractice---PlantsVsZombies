using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private Spawner _zombieSpawner;

    public List<GameObject> spawnPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        _zombieSpawner = new SunflowerZombieSpawner();

        InvokeRepeating("spawnZombie", 1f, 1f);
    }


    private void spawnZombie()
    {
        Debug.Log("Spawning zombie");
        Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position;
        _zombieSpawner.SpawnEnemy(spawnPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Zombie"))
        {
            Debug.Log("End game");
        }
    }
}
