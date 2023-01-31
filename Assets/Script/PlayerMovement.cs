using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMovement;
    public float jumpHeight;
    public Rigidbody2D playerBody;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool doubleJumped;
    private Animator animator;
    public Transform firePoint;
    public GameObject bullet;
    public float knockBack;
    public float knockBackLength;
    public float knockBackCount;
    public bool knockBackFromRight;    

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded)
        doubleJumped = false;
        animator.SetBool("Grounded",grounded);

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
           // playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight);                   
        }
        if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
           // playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight);
            doubleJumped = true;                   
        }
        if(knockBackCount <= 0)
        {
        if(Input.GetKeyDown(KeyCode.D))
        {
            playerBody.velocity = new Vector2(speedMovement,playerBody.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            playerBody.velocity = new Vector2(-speedMovement,playerBody.velocity.y);
        }
        }
        else
        {
            if(knockBackFromRight)
            {
                playerBody.velocity = new Vector2(-knockBack,knockBack);
            }
            if(!knockBackFromRight)
            {
                playerBody.velocity = new Vector2(knockBack,knockBack);
            }
            knockBackCount -=Time.deltaTime;
        }
        animator.SetFloat("Walk",Mathf.Abs(playerBody.velocity.x));

        if(playerBody.velocity.x > 0)
        transform.localScale = new Vector3(1,1,1);

        if(playerBody.velocity.x < 0)
        transform.localScale = new Vector3(-1f,1,1);
        if(Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(bullet,firePoint.position,firePoint.rotation);
            animator.SetTrigger("Shooting");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Sword");
        }
        
    }
    void Jump()
    {
       playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight); 
    }

     
}
