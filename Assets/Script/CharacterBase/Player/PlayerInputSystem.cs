using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static PlayerInputActions;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class PlayerInputSystem :MonoBehaviour, IGamePlayActions
{
    PlayerInputActions playerInputActions;


    public event UnityAction<Vector2> Move = delegate { };
    public event UnityAction<bool> Attack = delegate { };
    public event UnityAction<bool> Roll = delegate { };
    public event UnityAction<bool> Sprint = delegate { };
    
    public Vector2 axes => playerInputActions.GamePlay.Move.ReadValue<Vector2>();
    public bool isMove =>playerInputActions.GamePlay.Move.WasPressedThisFrame();
    public bool isAttack => playerInputActions.GamePlay.Attack.WasPressedThisFrame();
    public bool isRoll => playerInputActions.GamePlay.Roll.WasPressedThisFrame();
    public bool isSprint => playerInputActions.GamePlay.Sprint.WasPressedThisFrame();

    public Vector3 moveValue => new Vector3(GetSmoothInput().x, 0, GetSmoothInput().y);

    float smoothSpeed = 0.05f;
    Vector2 smoothInputVelocity;
    Vector2 smoothInput;
    private Vector2 GetSmoothInput()
    {
        smoothInput = Vector2.SmoothDamp(smoothInput, axes, ref smoothInputVelocity, smoothSpeed);
        return smoothInput;
    }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }
    public void EnableGamePlayInputs()
    {
        playerInputActions.GamePlay.Enable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Move?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        Attack?.Invoke(context.ReadValue<bool>());
    }
    public void OnRoll(InputAction.CallbackContext context)
    {
        Roll?.Invoke(context.ReadValue<bool>());
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        Sprint?.Invoke(context.ReadValue<bool>());
    }
}

// public bool isMove => Mathf.Abs(GetSmoothInput().x) > 0.1f|| Mathf.Abs(GetSmoothInput().y) > 0.1f;

//public bool Move => axes.x != 0 || axes.y != 0;




//public float Horizontal => GetSmoothInput().x;
//public float Vertical => GetSmoothInput().y;
//public Vector3 moveValue => new Vector3(GetSmoothInput().x, 0, GetSmoothInput().y);




