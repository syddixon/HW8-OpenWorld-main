using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float forceY = 1;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-25.91f, 0.16f, 0f);
        // Turn gravity off when game starts
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(forceY * Vector2.up);
        }
    }

    // level starts over when player collides with game object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // transform.position(collision.gameObject);
        transform.position = new Vector3(-25.91f, 0.16f, 0f);
    }
}
