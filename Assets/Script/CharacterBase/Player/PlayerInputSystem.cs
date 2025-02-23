using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    private Vector2 axes => playerInputActions.GamePlay.Move.ReadValue<Vector2>();
    private Vector2 smoothInputVelocity;
    private const float smoothSpeed = 0.05f;
    private Vector2 smoothInput;
    public float Horizontal => GetSmoothInput().x;
    public float Vertical => GetSmoothInput().y;
    public bool Move => Mathf.Abs(GetSmoothInput().x) > 0.1f || Mathf.Abs(GetSmoothInput().y) > 0.1f;
    public Vector3 moveValue => new Vector3(GetSmoothInput().x, 0, GetSmoothInput().y);
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

    private Vector2 GetSmoothInput()
    {
        smoothInput = Vector2.SmoothDamp(smoothInput, axes, ref smoothInputVelocity, smoothSpeed);
        return smoothInput;
    }

}
