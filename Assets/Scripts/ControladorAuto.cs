using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAuto : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticallInput;

    private float curretSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLefttWheelCollider;
    [SerializeField] private WheelCollider rearRighttWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform fronRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;


    //public float jumpForce;
    //public float jumpCooldown;
    //public float airMultiplier;
    //bool readtToJump;

    //public int maxJumpCount = 2;
    //public int jumpRestantes = 0;

    //[Header("Keybinds")]
    //public KeyCode jumpKey = KeyCode.J;

    //[Header("Ground Check")]
    //public float playerHeight;
    //public LayerMask whatIsGround;
    //bool grounded;

    //Rigidbody rb;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();

    //    readtToJump = true;
    //}

    //private void Update()
    //{
    //    grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

    //}

    private void FixedUpdate()
    {
        MyInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticallInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);

        //if (Input.GetKey(jumpKey) && readtToJump && grounded && (jumpRestantes > 0))
        //{
        //    readtToJump = false;

        //    Jump();
        //    jumpRestantes -= 1;

        //    Invoke(nameof(ResetJump), jumpCooldown);
        //}
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticallInput * motorForce;
        frontRightWheelCollider.motorTorque = verticallInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        rearLefttWheelCollider.brakeTorque = currentBreakForce;
        rearRighttWheelCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        curretSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = curretSteerAngle;
        frontRightWheelCollider.steerAngle = curretSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, fronRightWheelTransform);
        UpdateSingleWheel(rearRighttWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLefttWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }


    //private void Jump()
    //{
    //    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

    //    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    //}

    //private void ResetJump()
    //{
    //    readtToJump = true;
    //    jumpRestantes = maxJumpCount;
    //}

}
