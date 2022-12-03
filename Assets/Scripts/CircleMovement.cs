using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleMovement : MonoBehaviour
{
    public float m_Energy;
    private Rigidbody2D body;
    [SerializeField] private float speed;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        m_Energy = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed*m_Energy, body.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if(isGrounded && (Input.GetKey(KeyCode.Space) || Input.GetAxis("Vertical")>0)){
            body.AddForce(Vector2.up * m_Energy, ForceMode2D.Impulse);
        }
    }
}
