using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        private PlayerInputSystem input;
        private CharacterController playerController;
        private PlayerAnimController animController;
        private PlayerAttackManager attackManager;
        [SerializeField] private EnemyManager enemyManager;


        private float smoothSpeed = 0.05f;
        private float rotateSpeed = 0.05f;
        private float speed = 4f;

      
        private Vector2 smoothInputVelocity;
        private Vector2 adjustedDirection;
        private Vector3 moveValue => new Vector3(GetSmoothInput().x, 0, GetSmoothInput().y);

        #region System Function


        // Start is called before the first frame update
        void Start()
        {
            playerController = GetComponent<CharacterController>();
            animController = GetComponent<PlayerAnimController>();
            input = GetComponent<PlayerInputSystem>();
            attackManager = GetComponent<PlayerAttackManager>();
            //enemyManager= GetComponent<EnemyManager>();
            input.EnableGamePlayInputs();
           
        }

        // Update is called once per frame
        void Update()
        {
            CharacterRun();
            CharacterMove();
            CharacterRoll();
            CharacterSprint();
            CharacterAttack();
        }
        #endregion
        #region Charactor Movement
        private Vector2 GetSmoothInput()
        {
            var movementDirction = input.axes;
            adjustedDirection = Vector2.SmoothDamp(adjustedDirection, movementDirction, ref smoothInputVelocity, smoothSpeed);
            return adjustedDirection;
        }
        private void CharacterMove()
        {
            animController.SetAnimation("speed", moveValue.magnitude);
            playerController.Move(moveValue * speed * Time.deltaTime);
        }
        private void CharacterRoatition()
        {
            transform.rotation = Quaternion.LookRotation(input.moveValue,Vector3.zero);
        }
        private void CharacterRun()
        {
            if (input.isMove && !animController.IsBusy)
            {
                CharacterMove();
                CharacterRoatition();
            }

        }
        private void CharacterRoll()
        {

            if (input.isRoll && !animController.IsBusy)
            {
                animController.RollHaddler();
            }
        }
        private void CharacterAttack()
        {
            if (input.isAttack && !animController.IsBusy)
            {
                if (enemyManager.enemies.Count != 0)
                {
                    Enemy target = enemyManager.GetNearestTarget();
                    // Debug.Log(enemyManager.GetNearestTarget());
                    if (target != null)
                    {
                        transform.LookAt(target.transform);
                    }
                }
                animController.AttackHaddler();

            }
        }
        private void CharacterSprint()
        {
            if (input.isSprint && !animController.IsBusy)
            {
                animController.SprintHaddler();
            }
        }
        #endregion
    }
}


#region old Input
//float horizontal = Input.GetAxis("Horizontal");
//float vertical = Input.GetAxis("Vertical");
//float horizontal = input.Horizontal;
//float vertical = input.Vertical;

//if (animController.IsBusy == false)
//{
//    if (Mathf.Abs(horizontal) >= 0.1f || Mathf.Abs(vertical) >= 0.1f)
//    {
//        //var dir = horizontal * transform.right + vertical * transform.forward;
//        var move = new Vector3(horizontal, 0, vertical);
//        transform.rotation = Quaternion.LookRotation(move, Vector3.up);
//        playerController.Move(move * walkSpeed * Time.deltaTime);

//        animController.SetAnimation("speed", move.magnitude);
//    }
//    else
//    {
//        animController.SetAnimation("speed", 0);
//    }

//}
//else
//{
//    animController.SetAnimation("speed",0);
//}
#endregion