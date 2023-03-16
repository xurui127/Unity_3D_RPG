using FinitStateMachine;
using NPC_Player;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ComboAttackState_Player<T> : IState where T : BB_Player
{

    private T board;
    protected int currentAttackIndex = 0;
    protected readonly int defaultAttackIndex = 0;
    protected readonly int maxAttackIndex = 2;
    protected  int preAttackIndex = -1;
    private  List<IState> comboList;
    private IState preAttackState;
    private SubStateMachine subStateMachine;
    public ComboAttackState_Player(T board, SubStateMachine subStateMachine)
    {
        this.board = board;
        this.subStateMachine = subStateMachine;
    }

    public void OnCheck(StateMachine stateMachine)
    {

    }

    public void OnEnter(StateMachine stateMachine)
    {
      
        Debug.Log(preAttackIndex);

        //comboList[currentAttackIndex].OnEnter(stateMachine);
        //preAttackState = comboList[currentAttackIndex];

        subStateMachine.SwitchSubState(StateType.ATTACK, subStateMachine, board, 0);

        //currentAttackIndex++;
    }

    public void OnExit(StateMachine stateMachine)
    {

        //UnityEngine.Debug.Log("out Attack");
        //preAttackState.OnExit(stateMachine);

        //preAttackState.OnExit(stateMachine);
        //foreach(IState state in comboList)
        //{
        //    state.OnExit(stateMachine);
        //}

    }

    public void OnUpdate(StateMachine stateMachine)
    {
        //if (board.input.Attack && board.animController.CanDoCombo())
        //{
        //        preAttackIndex = currentAttackIndex;
        //        currentAttackIndex++;
        //    if (currentAttackIndex >= comboList.Count)
        //    {
        //        currentAttackIndex = 0;
        //    }
        //    if (preAttackIndex != currentAttackIndex)
        //    {
        //        //stateMachine.SwitchState(StateType.ATTACK, stateMachine, board);
        //    }
        //    //if (currentAttackIndex < maxAttackIndex)
        //    //{
        //    //    stateMachine.SwitchState(StateType.ATTACK,stateMachine,board);
        //    //    //comboList[currentAttackIndex].OnEnter(stateMachine);
        //    //}
        //    //else
        //    //{
        //    //    currentAttackIndex = defaultAttackIndex;
        //    //    stateMachine.SwitchState(StateType.ATTACK, stateMachine, board);
        //    //}

        //}
        if (board.animController.AnimIsFinished())
        {
            ResetAttackIndex();
            stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
        }
        if (board.animController.AnimIsFinished() && board.input.Move)
        {
            ResetAttackIndex();
            stateMachine.SwitchState(StateType.MOVE, stateMachine, board);
        }

    }

    private void ResetAttackIndex()
    {
        currentAttackIndex = defaultAttackIndex;
        preAttackIndex = -1;

    }

}
