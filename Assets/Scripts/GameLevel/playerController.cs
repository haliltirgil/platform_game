using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;

    public float jumpSpeed = 250f, jumpFrequency = 0.1f, nextJumpTime;

    private float horizontalMove;
    public float moveSpeed = 4.0f;
    
    

    private bool moveLeft;
    private bool moveRight;
  
    bool facingRight = true;
    
    public bool isGrounded = false;
    public Transform groundCheckPos;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        moveLeft = false;
        moveRight = false; 
    }

    
    void Update()
    {
        
        playerMovement();
        onGroundCheck();

        if (playerRB.velocity.x < 0 && facingRight) 
        {
            flipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            flipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad)) 
        {
            
            
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            jumpMove(jumpSpeed);
        }
    }

    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(horizontalMove, playerRB.velocity.y);
    }

    public void pointerDownLeft()
    {
        moveLeft = true;
    }

    public void pointerUpLeft()
    {
        moveLeft = false;
    }

    public void pointerDownRight()
    {
        moveRight= true;
    }
    public void pointerUpRight()
    {
        moveRight = false;
    }

    public void playerMovement()
    {
        if (moveLeft)
        {
            horizontalMove = -moveSpeed;
            playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
        }
        else if (moveRight)
        {
            horizontalMove = moveSpeed;
            playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
        }
        else
        {
            horizontalMove = 0;
            playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
        }
    }

    //yüzü gidilen yere çevirmek için kullanılır. 
    void flipFace()
    {
        facingRight = !facingRight; //toggle yapılır.
        
        Vector3 tempLocalscale = transform.localScale; // atama yaparak ve -1 ile çarparak sağa ve sola dönüş ayarlanır.
        tempLocalscale.x *= -1;
        transform.localScale = tempLocalscale;
    }

    // playerRB'ye addForce metodu ile y düzlemi üzerinde jumpSpeed kadar bir kuvvet uygulanır.
    public void jumpMove(float jumpSpeed)
    {
        //playerRB.AddForce(new Vector2(0f, jumpSpeed));
        if (playerRB.velocity.y == 0) 
        {
            playerRB.velocity = Vector2.up * jumpSpeed; // başka bir zıplatma kodu bunu kullanırken tabi jumpSpeedi biraz düşürmek gerekiyor(10f).
        }
    }

    void onGroundCheck()
    {
        isGrounded=Physics2D.OverlapCircle(groundCheckPos.position,groundCheckRadius,groundCheckLayer); // bir daire oluşuyor ve daire yere değiyorsa isGrounded değerine true atıyor.
        
        playerAnimator.SetBool("isGroundedAnim", isGrounded); // playerAnimator içindeki isGroundedAnim adlı değişkeni scriptte oluşturduğumuz yere değme bileşeni ile bağlıyor.
    }
}
