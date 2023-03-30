using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BaseCharacter
{
    private float _speed = 10;
    private float _timer = 3;
    void Update()
    {
        _timer -= Time.deltaTime;
        EnemyBulletMove();
    }
    void BulletEnemycheck()
    {
        if(_timer < 0)
        {
            EnemyBullet.Destroy(gameObject);
        }
    }
    void EnemyBulletMove()
    {
        rb.velocity = transform.up * _speed;
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("player"))
        {
            GameManager.Instance.Gameover();
        }
    }
}
