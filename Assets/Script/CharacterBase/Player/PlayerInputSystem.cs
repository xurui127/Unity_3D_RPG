using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
   private PlayerInputActions playerInputActions;
    
    Vector2 axes => playerInputActions.GamePlay.Move.ReadValue<Vector2>();
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
        smoothInput = Vector2.SmoothDamp(smoothInput, axes, ref smoothInputVelocity, smoothSpeed);
        return smoothInput;
    }
    public void ClearInputCache()
    {
        playerInputActions.GamePlay.Attack.Disable();

        playerInputActions.GamePlay.Attack.Enable();
    }
}
//public string GetInputKey()
//{
//    if (Move)
//    {
//        return playerInputActions.GamePlay.Move.name.ToString();
//    }
//    else if(Attack)
//    {
//        return playerInputActions.GamePlay.Attack.name.ToString();
//    }
//    else if (Roll)
//    {
//        return playerInputActions.GamePlay.Roll.name.ToString();
//    }
//    else if (Sprint)
//    {
//        playerInputActions.GamePlay.Sprint.name.ToString();
//    }
//    else
//    {
//        return "null";
//    }
//    return "null";
//}