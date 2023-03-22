using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
   private PlayerInputActions playerInputActions;
    
    Vector2 rawMovementInput => playerInputActions.GamePlay.Move.ReadValue<Vector2>();
    Vector2 smoothInputVelocity;
    Vector2 smoothInput;
    public float Horizontal => GetSmoothInput().x;
    public float Vertical => GetSmoothInput().y;
    public bool Move => Mathf.Abs(GetSmoothInput().x) > 0.1f|| Mathf.Abs(GetSmoothInput().y) > 0.1f;
    public Vector3 moveValue => new Vector3(GetSmoothInput().x, 0, GetSmoothInput().y);
    public bool Attack => playerInputActions.GamePlay.Attack.WasPressedThisFrame();
    public bool Roll => playerInputActions.GamePlay.Roll.WasPressedThisFrame();

    public bool Sprint => playerInputActions.GamePlay.Sprint.WasPressedThisFrame();

   // bool AttackClick => playerInputActions.GamePlay.Attack
    private float smoothSpeed = 0.05f;

    public Vector2 movementInput { get; private set; }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }
  
    private void Start()
    {
        EnableGamePlayInputs();
    }
    public void EnableGamePlayInputs()
    {
        playerInputActions.GamePlay.Enable();
    }

    private Vector2 GetSmoothInput()
    {
        smoothInput = Vector2.SmoothDamp(smoothInput, rawMovementInput, ref smoothInputVelocity, smoothSpeed);
        return smoothInput;
    }

   
}
