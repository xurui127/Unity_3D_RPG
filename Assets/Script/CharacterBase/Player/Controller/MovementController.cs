using UnityEngine;
namespace Player
{
    public class MovementController : MonoBehaviour
    {
        // Refences
        [Header("Refences")]
        private PlayerInputSystem input;
        private CharacterController playerController;
        private PlayerAnimController animController;
        private PlayerAttackManager attackManager;
        // [SerializeField] private EnemyManager enemyManager;

        [Header("Movements")]
        private Vector3 moveValue;
        private Vector2 smoothInputVelocity;
        private Vector2 smoothInput;
        private float smoothSpeed = 0.1f;
        private float speed = 4f;

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
        private void SmoothInput()
        {
            smoothInput = Vector2.SmoothDamp(smoothInput, input.GetAxesValue(), ref smoothInputVelocity, smoothSpeed);
        }
        // Update is called once per frame
        void Update()
        {
            CharacterRun();
            CharacterRoll();
            CharacterSprint();
            CharacterAttack();
        }
        #endregion
        #region Charactor Movement
        private void Move()
        {
            playerController.Move(moveValue * speed * Time.deltaTime);
        }
        private void CharacterRoatition()
        {
            if (moveValue != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveValue, Vector3.up);
            }
        }
        private void CharacterRun()
        {
            if (input.Move && !animController.IsBusy)
            {
                Move();
                CharacterRoatition();
            }
            SmoothInput();
            moveValue = new Vector3(smoothInput.x, 0, smoothInput.y);
            animController.OnMove(moveValue.magnitude);
        }
        private void CharacterRoll()
        {

            if (input.Roll && !animController.IsBusy)
            {
                animController.RollHaddler();
            }
        }
        private void CharacterAttack()
        {
            if (input.Attack && !animController.IsBusy)
            {
                //if (enemyManager.enemies.Count != 0)
                //{
                //    Enemy target = enemyManager.GetNearestTarget();
                //    if (target != null)
                //    {

                //        transform.LookAt(target.transform);
                //    }
                //}
                animController.OnAttack();
            }
        }
        private void CharacterSprint()
        {
            if (input.Sprint && !animController.IsBusy)
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