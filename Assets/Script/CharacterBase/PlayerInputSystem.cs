using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    Vector2 axes => playerInputActions.GamePlay.Move.ReadValue<Vector2>();
    public float Horizontal => axes.x;
    public float Vertical => axes.y;
    public bool Attack => playerInputActions.GamePlay.Attack.WasPressedThisFrame();
    public bool Roll => playerInputActions.GamePlay.Roll.WasPressedThisFrame();


    //public bool Move => axes.x != 0 || axes.y != 0;
    public bool Move => !playerInputActions.GamePlay.Move.WasReleasedThisFrame();
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();   
    }
    public void EnableGamePlayInputs()
    {
        playerInputActions.GamePlay.Enable();
    }
}
