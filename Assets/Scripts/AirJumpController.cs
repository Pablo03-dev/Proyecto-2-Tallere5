using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirJumpController : MonoBehaviour
{
    //Salto
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readtToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.J;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    Rigidbody rb;

    //Doble Salto
    //public int maxJumpCount = 2;
    //public int jumpRestantes = 0;


    //Control Aereo
    //public KeyCode rollRightInput = KeyCode.E;
    //public KeyCode rollLeftInput = KeyCode.Q;

    //public float rollRotationSpeed;
    //public float yawpitchRotationSpeed;

    //public float verticalInput;
    //public float horizontalInput;

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

            //AerialCarController();

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

    //private void AerialCarController()
    //{
    //    if (rollRightInput)
    //    {
    //        this.transform.Rotate(Vector3.back, rollRotationSpeed * Time.deltaTime);
    //    }
    //    else if (rollLeftInput)
    //    {
    //        this.transform.Rotate(Vector3.forward, rollRotationSpeed * Time.deltaTime);
    //    }

    //    //Handle Pitch/Yawn on WASD

    //    if (verticalInput > 0)
    //    {
    //        this.transform.Rotate(Vector3.right, yawpitchRotationSpeed * Time.deltaTime);
    //    }
    //    else if (verticalInput < 0)
    //    {
    //        this.transform.Rotate(Vector3.left, yawpitchRotationSpeed * Time.deltaTime);
    //    }

    //    if (horizontalInput < 0)
    //    {
    //        this.transform.Rotate(Vector3.up, yawpitchRotationSpeed * Time.deltaTime);
    //    }
    //    else if (horizontalInput > 0)
    //    {
    //        this.transform.Rotate(Vector3.down, yawpitchRotationSpeed * Time.deltaTime);
    //    }

    //}

}
