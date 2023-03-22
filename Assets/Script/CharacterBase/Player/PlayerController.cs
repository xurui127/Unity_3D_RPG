using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    private PlayerInputSystem input;
    private CharacterController playerController;
    private PlayerAnimController animController;
    private PlayerAttackManager attackManager;
    private EnemyManager enemyManager;
    //public float speed = 4f;
    

    // Player movement actions 
    public BB_Player board;
    private readonly Move move = new Move();
    private readonly Rotation rotation = new Rotation();
    private readonly Roll roll = new Roll();
    private readonly Attack attack = new Attack();
    private readonly Sprint sprint = new Sprint();


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        animController = GetComponent<PlayerAnimController>();
        input = GetComponent<PlayerInputSystem>();
        attackManager = GetComponent<PlayerAttackManager>();
        input.EnableGamePlayInputs();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (input.Move && !animController.IsBusy)
        {
            Debug.Log("In");
            move.Execute(board);
            rotation.Execute(board);
        }
        if (input.Roll && !animController.IsBusy)
        {
            roll.Execute(board);
        }
        if (input.Attack && !animController.IsBusy)
        {
            attack.Execute(board);
        }
        if (input.Sprint && !animController.IsBusy)
        {
            sprint.Execute(board);
        }
    }
}
