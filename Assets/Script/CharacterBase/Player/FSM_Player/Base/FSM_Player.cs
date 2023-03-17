using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static PlayerInputActions;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class FSM_Player : MonoBehaviour
{
    private StateMachine fsm_Player;
    public BB_Player board = new BB_Player();
    
    // Start is called before the first frame update
    void Start()
    {

        fsm_Player = new StateMachine();
        fsm_Player.Init(board);

        fsm_Player.AddState(StateType.IDLE,new IdleState_Player<BB_Player>(board));
        fsm_Player.AddState(StateType.MOVE,new MoveState_Player<BB_Player>(board));
        fsm_Player.AddState(StateType.SPRINT,new SprintState_Player<BB_Player>(board));
        fsm_Player.AddState(StateType.ROLL,new RollState_Player<BB_Player>(board));
        
        fsm_Player.AddSubState(StateType.ATTACK, new AttackOne_Player<BB_Player>(board));
        fsm_Player.AddSubState(StateType.ATTACK, new AttackTwoState_Player<BB_Player>(board));
        fsm_Player.AddSubState(StateType.ATTACK, new AttackThreeState_Player<BB_Player>(board));
        
        fsm_Player.SwitchState(StateType.IDLE, fsm_Player, board);
    }

    // Update is called once per frame
    void Update()
    {
        fsm_Player.OnUpdate(fsm_Player, board);
        
    }
}
