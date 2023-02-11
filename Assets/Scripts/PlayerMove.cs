using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
   
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;
    bool isAlive = true;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(5f,5f);
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();
        myBodyCollider = gameObject.GetComponent<CapsuleCollider2D>();
        myFeetCollider = gameObject.GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive){
            return;
        }
        Run();
        FlipSprite();
        Climbing();
        Die();
    }

    void FlipSprite()
    {
        bool playerIsMoving = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerIsMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    } 

    void Climbing()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing",false);
            return;
        }
            
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        bool playerIsClambing = Mathf.Abs(myRigidbody.velocity.y) >Mathf.Epsilon;
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;
        myAnimator.SetBool("isClimbing",playerIsClambing);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveSpeed * moveInput.x, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerIsMoving = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerIsMoving);

    }

    void Die (){
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy"))){
            isAlive = false;
            myAnimator.SetTrigger("Died");
            myRigidbody.velocity = deathKick;
        }
    }

    void OnMove(InputValue value)
    {
        if(!isAlive){
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if(!isAlive){
            return;
        }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
}
