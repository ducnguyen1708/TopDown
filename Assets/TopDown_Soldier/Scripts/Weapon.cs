using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletSpawner bulletSpawner;
    private float timerShoot;
    public float rate;
    void Update()
    {
        timerShoot -= Time.deltaTime;
    }
    public void Shoot()
    {
        if (timerShoot > 0) return;
        timerShoot = rate;
        var bullet = bulletSpawner.GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.gameObject.SetActive(true);
    }
}
