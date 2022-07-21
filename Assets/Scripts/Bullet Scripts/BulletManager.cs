using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] Transform spawnPoint;

    public void SpawnBullet()
    {
        var bulletInstance = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
