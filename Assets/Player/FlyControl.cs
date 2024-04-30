using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float forceY = 1;
    Rigidbody2D rb;
    AudioSource audioSource;
    //public int startGravity = 0;
    public int state = 0;

    //constant integers for each state
    int start_state = 0;
    int run_state = 1;
    int end_state = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = start_state;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == start_state)
        {
            transform.position = new Vector3(-25.91f, 0.16f, 0f); //start position
            rb.gravityScale = 0; // no gravity
        }

        if(state == end_state)
        {
            transform.position = new Vector3(212.6f, 0.16f, 0f); //end position
            rb.gravityScale = 0; // no gravity
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = run_state;
        }

        if(state == run_state)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.right);
            rb.gravityScale = 1;

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(forceY * Vector2.up);
                
            }
        }

        if(transform.position.x == 212.6)
        {
            state = end_state;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            state = start_state;
        }
    }

    // back to start, when player fails
    private void OnTriggerEnter2D(Collider2D collision)
    {
        state = start_state;
        audioSource.Play();
    }
}
