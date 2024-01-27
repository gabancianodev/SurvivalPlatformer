using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    Rigidbody2D EnemyRigid;
    SpriteRenderer EnemyRenderer;

    [SerializeField] Sprite EnemyLookLeft;
    [SerializeField] Sprite EnemyLookRight;


    [SerializeField] bool changeDir;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRigid = GetComponent<Rigidbody2D>();
        EnemyRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (changeDir)
        {
            EnemyRigid.velocity = new Vector2(movementSpeed, EnemyRigid.velocity.y);
            EnemyRenderer.sprite = EnemyLookRight;
        }
        else
        {
            EnemyRigid.velocity = new Vector2(-movementSpeed, EnemyRigid.velocity.y);
            EnemyRenderer.sprite = EnemyLookLeft;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (changeDir)
                changeDir = false;
            else
                changeDir = true;
        }
    }
}
