using System.Collections;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player stuff")]
    public Rigidbody2D rb;
    public groundDetection gd;
    public bool isMoving = false;
    public bool isGrounded = true;
    public bool canMove = true;

    [Header("Attacks")]
    public int atkLevel = 0;
    public BasicAttack ba;
    public bool isAttacking = false;
    public float attackCD = 0.5f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isAttacking)
        {
            canMove = false;
            ba.gameObject.SetActive(true);
            attackCD -= Time.deltaTime;
            if(attackCD <= 0)
            {
                ba.gameObject.SetActive(false);
                attackCD = 0.5f;
                isAttacking = false;
                canMove = true;
            }
        }
    }
}
