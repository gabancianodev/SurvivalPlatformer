using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePadBehavior : MonoBehaviour
{
    [Header("Bounce References")]
    [SerializeField] Sprite bouncePadClose;
    [SerializeField] Sprite bouncePadPopped;

    SpriteRenderer bounceSprite;

    void Start()
    {
        bounceSprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            bounceSprite.sprite = bouncePadPopped;
        }
    }

    private void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            bounceSprite.sprite = bouncePadPopped;
        }
    }
}
