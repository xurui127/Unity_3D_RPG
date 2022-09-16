using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        #region System Function
        private Animator anim;
        private CharacterController playerController;
        private float walkSpeed = 4f;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            playerController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            CharacterMove();
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
                anim.SetFloat("speed", move.magnitude);
            }
        }
        #endregion
    }
}

