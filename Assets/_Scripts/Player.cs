using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [Space]
    [SerializeField] bool isIdle;
    [SerializeField] bool isWalking;
    [SerializeField] bool isJumping;
    [Space]
    [SerializeField] bool isGrounded;

    SpriteRenderer playerSprite;
    Rigidbody2D playerRigid;
    Animator playerAnim;

    //Anim ID names
    const string ID_ANIM_IDLE = "isIdle";
    const string ID_ANIM_WALK = "isWalking";
    const string ID_ANIM_JUMP = "isJumping";

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerRigid = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlPlayer();
        
        
    }

    void ControlPlayer()
    {
        //Keyboard Controls
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigid.velocity = new Vector2(-speed * Time.deltaTime, playerRigid.velocity.y);
            playerSprite.flipX = false;

            if (isGrounded)
            {
                isWalking = true;
                isIdle = false;
            }
            

            UpdateAnims();
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerRigid.velocity = Vector2.zero;

            if (isGrounded)
            {
                isWalking = false;
                isIdle = true;
            }

            UpdateAnims();
        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerRigid.velocity = new Vector2(speed * Time.deltaTime, playerRigid.velocity.y);
            playerSprite.flipX = true;

            if (isGrounded)
            {
                isWalking = true;
                isIdle = false;
            }

            UpdateAnims();
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerRigid.velocity = Vector2.zero;

            if (isGrounded)
            {
                isWalking = false;
                isIdle = true;
            }

            UpdateAnims();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerRigid.velocity = new Vector2(playerRigid.velocity.x, jumpForce * Time.deltaTime);

                isJumping = true;
                isWalking = false;
                isIdle = false;

                UpdateAnims();
            }
        }
    }

    void UpdateAnims()
    {
        playerAnim.SetBool(ID_ANIM_IDLE, isIdle);
        playerAnim.SetBool(ID_ANIM_WALK, isWalking);
        playerAnim.SetBool(ID_ANIM_JUMP, isJumping);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            isJumping = false;

            UpdateAnims();
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

            isIdle = true;

            UpdateAnims();
        }
    }
}
