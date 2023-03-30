using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter
{
    [SerializeField] private float cooldown = 2;
    private float _cooldownTimer;
    public GameObject EnemybulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _cooldownTimer -= Time.deltaTime;
        FollowPlayer();
    }
    void LateUpdate() {
        EnemyBullet();    
    }
    void FollowPlayer()
    {
        var player = GameManager.Instance.player;
        var rotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.back);
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;
        rb.velocity = transform.up * speed;
    }
    public void Dead()
    {
        Enemy.Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            Debug.Log("GameOver.............");
            Destroy(col.gameObject);
            GameManager.Instance.Gameover();
        }
    }
    public void EnemyBullet()
    {
        if (_cooldownTimer > 0) return;
        _cooldownTimer = cooldown;
        Instantiate(EnemybulletPrefab, transform.position, transform.rotation);

    }
}
