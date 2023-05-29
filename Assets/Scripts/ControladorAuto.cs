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

    [SerializeField] private WheelCollider DelanteraIzquieCollider;
    [SerializeField] private WheelCollider DelanteraDerechaCollider;
    [SerializeField] private WheelCollider TraseraIzquieCollider;
    [SerializeField] private WheelCollider TraseraDerechaCollider;

    [SerializeField] private Transform DelanteraIzquieTransform;
    [SerializeField] private Transform DelanteraDerechaTransform;
    [SerializeField] private Transform TraseraIzquierdaTransform;
    [SerializeField] private Transform TraseraDerechaTransform;


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
        DelanteraIzquieCollider.motorTorque = verticallInput * motorForce;
        DelanteraDerechaCollider.motorTorque = verticallInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        DelanteraDerechaCollider.brakeTorque = currentBreakForce;
        DelanteraIzquieCollider.brakeTorque = currentBreakForce;
        TraseraIzquieCollider.brakeTorque = currentBreakForce;
        TraseraDerechaCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        curretSteerAngle = maxSteerAngle * horizontalInput;
        DelanteraIzquieCollider.steerAngle = curretSteerAngle;
        DelanteraDerechaCollider.steerAngle = curretSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(DelanteraIzquieCollider, DelanteraIzquieTransform);
        UpdateSingleWheel(DelanteraDerechaCollider, DelanteraDerechaTransform);
        UpdateSingleWheel(TraseraDerechaCollider, TraseraDerechaTransform);
        UpdateSingleWheel(TraseraIzquieCollider, TraseraIzquierdaTransform);
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
