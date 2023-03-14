using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Player : MonoBehaviour
{
    public StateMachine fsm_Player;
    public BB_Player board = new BB_Player();
    [SerializeField]private List<IState> comboList = new List<IState>();
    // Start is called before the first frame update
    void Start()
    {

        fsm_Player = new StateMachine();
        fsm_Player.Init(board);

        fsm_Player.AddState(StateType.IDLE,new IdleState_Player<BB_Player>(board));
        fsm_Player.AddState(StateType.MOVE,new MoveState_Player<BB_Player>(board));
        comboList.Add(new AttackOne_Player<BB_Player>(board));
        comboList.Add(new AttackTwoState_Player<BB_Player>(board));
        comboList.Add(new AttackThreeState_Player<BB_Player>(board));

        fsm_Player.AddState(StateType.ATTACK,new ComboAttackState_Player<BB_Player>(board, comboList));
        fsm_Player.SwitchState(StateType.IDLE, fsm_Player, board);
    }

    // Update is called once per frame
    void Update()
    {
        fsm_Player.OnUpdate(fsm_Player, board);
    }
}
