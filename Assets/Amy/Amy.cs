using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amy : MonoBehaviour
{
    [SerializeField] float forceX = 1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(forceX * Vector2.right);
        }
    }
}
