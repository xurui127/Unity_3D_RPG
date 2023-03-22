using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.Rendering.Universal;

public class PlayerInput : MonoBehaviour
{
    // Movement
    private Vector2 axes;
    private Vector2 smoothInputVelocity;
    private Vector2 smoothInput;
    private float inputSmoothSpeed = 0.05f;
    public Vector2 movementInput { get; private set; }
    public bool Move => Mathf.Abs(GetSmoothInput().x) > 0.1f || Mathf.Abs(GetSmoothInput().y) > 0.1f;


    public void OnMoveInput(InputAction.CallbackContext context)
    {
        axes = context.ReadValue<Vector2>();
        movementInput = new Vector2(GetSmoothInput().x, GetSmoothInput().y);
        transform.rotation = Quaternion.LookRotation(movementInput, Vector3.up);
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
        smoothInput = Vector2.SmoothDamp(smoothInput, axes, ref smoothInputVelocity, inputSmoothSpeed);
        return smoothInput;
    }
}
