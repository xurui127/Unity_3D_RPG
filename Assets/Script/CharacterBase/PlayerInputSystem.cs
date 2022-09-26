using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    Vector2 axes => new  Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    public float Horizontal => axes.x;
    public float Vertical => axes.y;    

    public bool Move => Mathf.Abs(Horizontal) > 0.1f ||Mathf.Abs(Vertical) > 0.1f;

    public Vector3 moveValue => new Vector3(Horizontal, 0, Vertical);

    public bool Attack => Input.GetButtonDown("Attack");
    public bool Roll => Input.GetButtonDown("Roll");
    


}

// PlayerInputActions playerInputActions;

// Vector2 axes => playerInputActions.GamePlay.Move.ReadValue<Vector2>();
// Vector2 smoothInputVelocity;
// [SerializeField]float smoothSpeed = 0.025f;
// Vector2 smoothInput;
// public float Horizontal => GetSmoothInput().x;
// public float Vertical => GetSmoothInput().y;
// public bool Move => Mathf.Abs(GetSmoothInput().x) > 0.1f|| Mathf.Abs(GetSmoothInput().y) > 0.1f;

// public Vector3 moveValue => new Vector3(GetSmoothInput().x, 0, GetSmoothInput().y);
// public bool Attack => playerInputActions.GamePlay.Attack.WasPressedThisFrame();
// public bool Roll => playerInputActions.GamePlay.Roll.WasPressedThisFrame();



// //public bool Move => axes.x != 0 || axes.y != 0;
//// public bool Move =>playerInputActions.GamePlay.Move.WasPressedThisFrame();
// private void Awake()
// {
//     playerInputActions = new PlayerInputActions();   
// }
// public void EnableGamePlayInputs()
// {
//     playerInputActions.GamePlay.Enable();
// }
// public void Update()
// {

// }

// private Vector2 GetSmoothInput()
// {
//     smoothInput = Vector2.SmoothDamp(smoothInput, axes, ref smoothInputVelocity, smoothSpeed);
//     return smoothInput;
// }