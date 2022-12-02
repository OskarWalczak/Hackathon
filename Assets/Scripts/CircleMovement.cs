using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleMovement : MonoBehaviour
{

    private Rigidbody2D body;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);

        if(Input.GetKey(KeyCode.Space) || Input.GetAxis("Vertical")>0)
            body.velocity = new Vector2(body.velocity.x, speed);
    }
}
