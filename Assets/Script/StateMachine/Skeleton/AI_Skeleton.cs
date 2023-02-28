using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI_Enemy;
using UnityEngine.UI;

public class AI_Skeleton : MonoBehaviour
{
    private FSM_Enemy fsm_Skeleton;
    public BB_Skeleton board = new BB_Skeleton();
    // Start is called before the first frame update
    void Start()
    {
        fsm_Skeleton = new FSM_Enemy();
        fsm_Skeleton.Init(board);
        fsm_Skeleton.AddState(StateType.IDLE, new IdleState(board));
        fsm_Skeleton.AddState(StateType.MOVE, new MoveState(board));
        fsm_Skeleton.SwitchState(StateType.IDLE,fsm_Skeleton,board);
    }

    // Update is called once per frame
    void Update()
    {
        fsm_Skeleton.OnUpdate(fsm_Skeleton,board);
    }
}
