using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class NewPlayerInputSystem : MonoBehaviour
{
    public Vector2 rawMovementInput;
    private Vector2 smoothInputVelocity;
    private Vector2 smoothInput;
    private Vector2 rotationInput;
    private float inputSmoothSpeed = 0.05f;
    private float Horizontal;
    private float Vertical;
    public Vector3 movementInput { get; private set; }
   
    public bool Move;  
    //=> Mathf.Abs(GetSmoothInput().x) > 0.1f || Mathf.Abs(GetSmoothInput().y) > 0.1f
   
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Move = true;
        rawMovementInput = context.ReadValue<Vector2>();
        movementInput = new Vector3(GetSmoothInput().x, 0, GetSmoothInput().y);
        transform.rotation = Quaternion.LookRotation(movementInput, Vector3.up);
        if (context.canceled)
        {
            Move = false;
            rawMovementInput = new Vector2(0,0);
        }

    }
    public void OnAttackInput(InputAction.CallbackContext context)
    {

    }
    public void OnRollInput(InputAction.CallbackContext context)
    {

    }
    public void OnSprintInput(InputAction.CallbackContext context)
    {

    }

    private Vector2 GetSmoothInput()
    {
        smoothInput = Vector2.SmoothDamp(smoothInput, rawMovementInput, ref smoothInputVelocity, inputSmoothSpeed);
        return smoothInput;
    }
}
