using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class PlayerInputSystem : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    public Vector2 axes => playerInputActions.GamePlay.Move.ReadValue<Vector2>();
    public bool Move => Mathf.Abs(axes.magnitude) > 0.1f;
    public bool Attack => playerInputActions.GamePlay.Attack.WasPressedThisFrame();
    public bool Roll => playerInputActions.GamePlay.Roll.WasPressedThisFrame();
    public bool Sprint => playerInputActions.GamePlay.Sprint.WasPressedThisFrame();

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }
    public void EnableGamePlayInputs()
    {
        playerInputActions.GamePlay.Enable();
    }
    public Vector2 GetAxesValue()
    {
        return axes;
    }

}
//public Vector3 axesValue => new Vector3(SmoothInput().x, 0, SmoothInput().y);
//private Vector2 smoothInputVelocity;
//private Vector2 smoothInput;
//private float smoothSpeed = 0.5f;
//private Vector2 SmoothInput()
//{
//    smoothInput = Vector2.SmoothDamp(smoothInput, axes, ref smoothInputVelocity, smoothSpeed);
//    return smoothInput;
//}
