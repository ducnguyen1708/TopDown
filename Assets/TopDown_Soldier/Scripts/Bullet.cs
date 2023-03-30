using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public float speed = 10;
    [SerializeField] private float range = 10;
    private Vector3 _startPosition;
    private void OnEnable()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        moveBullet();
        CheckBullet();

    }
    void CheckBullet()
    {
        if ((transform.position - _startPosition).magnitude > range)
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }
    void moveBullet()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Enemy"))
        {
            Enemy enemy = col.GetComponent<Enemy>();
            enemy.Dead();
            DestroyBullet();
        }
    }
}
