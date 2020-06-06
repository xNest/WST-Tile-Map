using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer m_SpriteRenderer;
    private Vector2 movment;
    private bool isJump = false;
    private bool ground = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isJump = Input.GetButtonDown("Jump") && ground;
        if (isJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            ground = false;
        }
    }

    void FixedUpdate()
    {
        //get the Input from Horizontal axis
        movment.x = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        movment.y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(movment.x * movementSpeed, rb.velocity.y);


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            ground = true;
        }

    }


}