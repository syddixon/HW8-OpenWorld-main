using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float forceX = 1;
    [SerializeField] float forceY = 1;
    Rigidbody2D rb;
    bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(forceX * Vector2.right);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(forceX * Vector2.left);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(forceY * Vector2.up);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if we collide with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
        {
        //check if we collide with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;

        }
        }
}
