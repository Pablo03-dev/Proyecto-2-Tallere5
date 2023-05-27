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

}
