using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCarController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpHeight;
    //public float jumpForce;

    public bool isGrounded;

    public int maxJumpCount = 2;
    public int jumpsRemaining = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (jumpsRemaining > 0))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumpsRemaining -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            jumpsRemaining = maxJumpCount;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;

        }
    }
}
