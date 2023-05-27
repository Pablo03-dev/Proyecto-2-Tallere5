using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAirController : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode RollRightInput = KeyCode.Q;
    public KeyCode RollLefttInput = KeyCode.E;

    public float rollRotationSpeed;

    public float groundedCheckDistance;
    bool isGrounded = true;

    private void FixedUpdate()
    {
        isGrounded = CheckIsGrounded();

        if (!isGrounded)
        {

        }
    }

    public void AerialCarControl()
    {
        //Handle air roll on q and e
        //if (RollRightInput)
        //{
        //    this.transform.Rotate(Vector3.back, rollRotationSpeed * Time.deltaTime);
        //}
    }







    public bool CheckIsGrounded()
    {
        RaycastHit hit;
        bool grounded;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundedCheckDistance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        Debug.DrawRay(transform.position, -transform.up.normalized * groundedCheckDistance, Color.green);

        return grounded;

    }

}
