using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public Animator playerAnim;
    public float speed = 10;
    private static readonly int WalkPlayer = Animator.StringToHash("Walk");
    private static readonly int AttackPlayer = Animator.StringToHash("Attack");
    [SerializeField]
    private Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }
    void MovePlayer()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var moveDirection = new Vector2(x,y).normalized;
        playerAnim.SetFloat(WalkPlayer,moveDirection.magnitude);
        rb.velocity = moveDirection * speed;
    }
    void CheckRotation()
    {
        var screenMousePosition = Input.mousePosition;
        var mousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
        var rotation = Quaternion.LookRotation(mousePosition - transform.position, Vector3.back);
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;
    }
    void Attack()
    {
        CheckRotation();
        if(Input.GetAxis("Fire1") > 0)
        {
            playerAnim.SetTrigger(AttackPlayer);
            weapon.Shoot();
        }
    }
}
