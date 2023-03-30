using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float speed = 5;
    [SerializeField] protected float hp = 100;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
