using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleMovement : MonoBehaviour
{

    private Rigidbody2D body;
    [SerializeField] private float speed;
    private Animator anim;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    public bool shouldDie;
    public LayerMask deathLayer;

    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal_input*speed, body.velocity.y);

        if (horizontal_input > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontal_input < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        shouldDie = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, deathLayer);

        if(isGrounded && (Input.GetKey(KeyCode.Space) || Input.GetAxis("Vertical")>0)){
            body.AddForce(Vector2.up, ForceMode2D.Impulse);
        }

        if(shouldDie){
            die();
        }
        
        anim.SetBool("run", horizontal_input != 0);
    }

    private void die(){
        body.position = new Vector2(-8, 8);
    }
}
