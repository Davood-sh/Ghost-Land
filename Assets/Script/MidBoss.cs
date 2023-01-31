using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBoss : MonoBehaviour
{
    //public SpriteRenderer sprite;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;
    private Rigidbody2D enemeyRigid;
    public float moveSpeed;
    public bool moveRight;
    private bool notEdge;
    public Transform edgeCheck;
    // Start is called before the first frame update
    void Start()
    {
        enemeyRigid = GetComponent<Rigidbody2D>();
        //sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position,wallCheckRadius,whatIsWall);
        notEdge = Physics2D.OverlapCircle(edgeCheck.position,wallCheckRadius,whatIsWall);
        if(hittingWall || !notEdge)
        moveRight = !moveRight;

        if(moveRight)
        {
            //sprite.flipX = false;
            transform.localScale = new Vector3 (-0.9f,0.9f,0.9f);
            enemeyRigid.velocity = new Vector2(moveSpeed,enemeyRigid.velocity.y);
        }
        else
        {
            //sprite.flipX = true;
            transform.localScale = new Vector3 (0.9f,0.9f,0.9f);
            enemeyRigid.velocity = new Vector2(-moveSpeed,enemeyRigid.velocity.y);
        }
        
    }
}
