using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleMovement : MonoBehaviour
{

    private Rigidbody2D body;
    [SerializeField] private float speed;

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
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        shouldDie = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, deathLayer);

        if(isGrounded && (Input.GetKey(KeyCode.Space) || Input.GetAxis("Vertical")>0)){
            body.AddForce(Vector2.up, ForceMode2D.Impulse);
        }

        if(shouldDie){
            die();
        }
    }

    private void die(){
        body.position = new Vector2(-8, 8);
    }
}
