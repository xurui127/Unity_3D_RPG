using UnityEngine;

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
