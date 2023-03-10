using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    private PlayerInputSystem input;
    private CharacterController playerController;
    private PlayerAnimController animController;
    private PlayerAnimManager animManager;
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
        animManager = GetComponent<PlayerAnimManager>();
        input.EnableGamePlayInputs();
        board = new BB_Player(this.transform,
                              input, playerController,
                              animController,
                              attackManager,
                              4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        //&& !animController.isBusy
        if (input.Move && !animManager.IsBusy)
        {
            move.Execute(board);
            rotation.Execute(board);
        }
        if (input.Roll && !animManager.IsBusy)
        {
            roll.Execute(board);
        }
        if (input.Attack && !animManager.IsBusy)
        {
            attack.Execute(board);
        }
        if (input.Sprint && !animManager.IsBusy)
        {
            sprint.Execute(board);
        }
    }
}
