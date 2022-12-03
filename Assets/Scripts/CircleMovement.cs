using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleMovement : MonoBehaviour
{
    public float m_Energy;
    private Rigidbody2D body;
    public float speed;
    public float jumpSpeed;
    private Animator anim;

    public bool isGrounded;
    public Transform groundCheck;
    public Transform groundCheck2;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    public bool shouldDie;
    public LayerMask deathLayer;

    // Start is called before the first frame update
    private void Awake()
    {
        m_Energy = 1f;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal_input*speed*m_Energy, body.velocity.y);

        if (horizontal_input > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontal_input < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) || Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, groundLayer);

        shouldDie = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, deathLayer) || Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, deathLayer);

        if(isGrounded && (Input.GetKey(KeyCode.Space) || Input.GetAxis("Vertical")>0))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed * m_Energy);
        }

        if(shouldDie)
        {
            die();
        }

        anim.SetBool("run", horizontal_input != 0);
    }

    private void die(){
        body.position = new Vector2(-8, 8);
    }
}
