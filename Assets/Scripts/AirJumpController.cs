using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirJumpController : MonoBehaviour
{

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readtToJump;

    //public int maxJumpCount = 2;
    //public int jumpRestantes = 0;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.J;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    Rigidbody rb;


    private void FixedUpdate()
    {
        AirInput();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        readtToJump = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

    }

    private void AirInput()
    {
        if (Input.GetKey(jumpKey) && readtToJump && grounded) //&& (jumpRestantes > 0)
        {
            readtToJump = false;

            Jump();
            //jumpRestantes -= 1;

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readtToJump = true;
        //jumpRestantes = maxJumpCount;
    }

}
