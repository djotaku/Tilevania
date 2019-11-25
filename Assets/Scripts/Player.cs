using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configs
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    // State
    bool isAlive = true; 

    // Cached Component References
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    Collider2D myCollider2D;

    // Messages

    // Methods
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        ClimbLadder();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");  //value is -1 to 1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
        
    }

    private void ClimbLadder()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            return;
        }

        float controlThrow = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, controlThrow * climbSpeed);
        myRigidbody.velocity = climbVelocity;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            { return;  }
            
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
    }


    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}