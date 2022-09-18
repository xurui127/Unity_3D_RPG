using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        #region System Function
        private CharacterController playerController;
        private float walkSpeed = 4f;
        private AnimController animController;

        // Start is called before the first frame update
        void Start()
        {
            playerController = GetComponent<CharacterController>();
            animController = GetComponent<AnimController>();
        }

        // Update is called once per frame
        void Update()
        {

            CharacterMove();
            CharacterRoll();
            CharacterAttack();

           // Debug.Log(animController.AnimStateMachine.isBusy);
        }
        #endregion
        #region Charactor Movement
        private void CharacterMove()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (Mathf.Abs(horizontal) >= 0.1f || Mathf.Abs(vertical) >= 0.1f)
            {
                //var dir = horizontal * transform.right + vertical * transform.forward;
                var move = new Vector3(horizontal, 0, vertical);
                transform.rotation = Quaternion.LookRotation(move, Vector3.up);
                playerController.Move(move * walkSpeed * Time.deltaTime);
                animController.Anim.SetFloat("speed", move.magnitude);
            }
        }
        private void CharacterRoll()
        {
            if (Input.GetButtonDown("Roll"))
            {
               
                    animController.Anim.SetTrigger("roll");
                
            }
        }
        private void CharacterAttack()
        {
            if (Input.GetButtonDown("Attack"))
            {
                  animController.Anim.SetTrigger("attack");
            }
        }
        #endregion
    }
}

