using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] Transform spawnPoint;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBullet()
    {
        var bulletInstance = Instantiate(bulletPrefab, spawnPoint);
    }
}
