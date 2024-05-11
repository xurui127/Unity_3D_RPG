using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
        if (input.Move )
        {
            if (animController.IsBusy)
            {
                return;
            }
            move.Execute(board);
            rotation.Execute(board);
        }
        if (input.Roll)
        {
            roll.Execute(board);
        }
        if (input.Attack)
        {
            attack.Execute(board);
        }
        if (input.Sprint)
        {
            sprint.Execute(board);
        }
    }
}
