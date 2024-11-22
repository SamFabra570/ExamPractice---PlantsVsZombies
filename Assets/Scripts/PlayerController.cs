using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float bulletSpeed;
    public float fireRate, bulletDamage;

    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    public List<GameObject> waypoints;
    public float moveSpeed = 2;
    private int index = 3;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
        
    }
    
    private void Shoot()
    {
        //GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("target").transform);
        GameObject bullet = ObjectPool.instance.GetPooledObject(); 
        if (bullet != null) {
            bullet.transform.position = GameObject.FindGameObjectWithTag("target").transform.position;
            bullet.SetActive(true);
        }
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);
    }

    private void Move()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        transform.position = newPos;
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (index > 0)
            {
                index--;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index < waypoints.Count - 1)
            {
                index++;
            }
        }
        
    }
}
