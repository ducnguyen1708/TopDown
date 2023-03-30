using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    [SerializeField] private int poolSize = 10;
    private Bullet[] _bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        _bulletPool = new Bullet[poolSize];
        for(int i = 0; i < poolSize; i++)
        {
            var bulletObject = Instantiate(BulletPrefab);
            bulletObject.SetActive(false);
            _bulletPool[i] = bulletObject.GetComponent<Bullet>();
        }
    }

    public Bullet GetBullet()
    {
        for (int i = 0; i < _bulletPool.Length; i++)
        {
            if(!_bulletPool[i].gameObject.activeSelf)
            {
                return _bulletPool[i];
            }
        }

        // TODO: Mở rộng kích thước object pool
        return null;
    }
}
