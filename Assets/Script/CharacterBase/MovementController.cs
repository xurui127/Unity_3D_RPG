using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        private PlayerInputSystem input;
        private CharacterController playerController;
        private AnimController animController;
        private PlayerAttackManager attackManager;
        private EnemyManager enemyManager;
        private float speed = 4f;
        #region System Function


        // Start is called before the first frame update
        void Start()
        {
            playerController = GetComponent<CharacterController>();
            animController = GetComponent<AnimController>();
            input = GetComponent<PlayerInputSystem>();
            attackManager = GetComponent<PlayerAttackManager>();
            enemyManager= GetComponent<EnemyManager>();
            input.EnableGamePlayInputs();
        }

        // Update is called once per frame
        void Update()
        {
            CharacterRun();
            //CharacterMove();
            CharacterRoll();
            CharacterSprint();
            CharacterAttack();
        }
        #endregion
        #region Charactor Movement
        private void CharacterMove()
        {
            animController.SetAnimation("speed", input.moveValue.magnitude);
            playerController.Move(input.moveValue * speed * Time.deltaTime);
        }
        private void CharacterRoatition()
        {
            transform.rotation = Quaternion.LookRotation(input.moveValue, Vector3.up);
        }
        private void CharacterRun()
        {
            if (input.Move && !animController.IsBusy)
            {
                CharacterMove();
                CharacterRoatition();
            }

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
                if (enemyManager.enemies.Count != 0)
                {
                    transform.LookAt(enemyManager.Target.transform);
                }
                animController.AttackHaddler();

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