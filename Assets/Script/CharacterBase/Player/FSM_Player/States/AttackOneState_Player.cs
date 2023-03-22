using FinitStateMachine;
using NPC_Player;


public class AttackOne_Player<T> : IState where T : BB_Player
{
    private T board;
    private int attackIndex = 1;
   


    public AttackOne_Player(T board)
    {
        this.board = board;
      

    }
    public void OnCheck(StateMachine stateMachine)
    {

    }
    public void OnEnter(StateMachine stateMachine)
    {
       
        board.animController.OnAttack(attackIndex);
        CombatEventManager.Instance.TriggerEventListener(NPCEventType.AttackBegin.ToString());
    }

    public void OnExit(StateMachine stateMachine)
    {

        CombatEventManager.Instance.TriggerEventListener(NPCEventType.AttackEnd.ToString());



    }

    public void OnUpdate(StateMachine stateMachine)
    {
        if (board.animController.CanDoCombo(0.4f, 1f))
        {
            if (board.input.Attack)
            {
                stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 1);
            }
            else if (board.input.Sprint)
            {
                stateMachine.SwitchState(StateType.SPRINT, stateMachine, board);
            }
            else if (board.input.Roll)
            {
                stateMachine.SwitchState(StateType.ROLL, stateMachine, board);
            }
        }
       
        if (board.animController.AnimIsFinished())
        {
            stateMachine.SwitchState(StateType.IDLE, stateMachine, board);

        }


        //if (!board.animController.IsInAction())
        //{
        //    stateMachine.SwitchState(StateType.IDLE, stateMachine, board);

        //}
        //if (!board.animController.IsInAction())
        //{
        //    stateMachine.SwitchState(StateType.IDLE, stateMachine, board);

        //}

    }
}

//if (board.input.Attack)
//{
//    if (Time.time - lastAttackTime <= attackTimeOut)
//    {
//        stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 1);
//    }
//    else
//    {
//        stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
//    }
//}
//if (board.animController.CanDoCombo())
//{
//    if (board.input.Attack)
//    {
//        inputList.Add(StateType.ATTACK);
//    }
//    if (board.input.Roll)
//    {
//        inputList.Add(StateType.ROLL);
//    }
//    if (board.input.Sprint)
//    {
//        inputList.Add(StateType.SPRINT);
//    }
//}

//if (board.animController.IsInCombo())
//{

//    if (inputList.Count != 0)
//    {
//        var input = inputList[inputList.Count - 1];
//        inputList.Clear();
//        if (input == StateType.ATTACK)
//        {
//            stateMachine.SwitchSubState(input, stateMachine, board, 1);

//        }
//        else
//        {
//            stateMachine.SwitchState(input, stateMachine, board);
//        }
//    }

//}
//if (board.animController.CanDoCombo())
//{
//    if (board.input.Attack)
//    {
//        stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 1);
//    }
//    else if (board.input.Sprint)
//    {
//        stateMachine.SwitchState(StateType.SPRINT, stateMachine, board);
//    }
//    else if (board.input.Roll)
//    {
//        stateMachine.SwitchState(StateType.ROLL, stateMachine, board);
//    }
//}
//if (board.input.Attack)
//{
//    inputCache.Add(StateType.ATTACK);
//    lastInputTime = Time.time;
//}
//else if (board.input.Roll)
//{
//    inputCache.Add(StateType.ROLL);
//    lastInputTime = Time.time;
//}
//else if (board.input.Sprint)
//{
//    inputCache.Add(StateType.SPRINT);
//    lastInputTime = Time.time;
//}

//if (Time.time - lastInputTime > comboTimeOut)
//{
//    inputCache.Clear();
//}
//else if (inputCache.Count > 1)
//{
//    int size = inputCache.Count - 1;
//    if (inputCache[size] != inputCache[size - 1])
//    {
//        if (inputCache[size] == StateType.ATTACK)
//        {
//            stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 1);
//        }
//        else
//        {
//            stateMachine.SwitchState(inputCache[size], stateMachine, board);
//        }
//        inputCache.Clear();
//    }
//}
//if (board.animController.IsInCombo() && board.animController.IsInAction())
//{
//    if (board.input.Attack)
//    {
//        stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 1);
//    }
//}
//else if (!board.animController.IsInAction())
//{
//    stateMachine.SwitchState(StateType.IDLE, stateMachine, board);

//}