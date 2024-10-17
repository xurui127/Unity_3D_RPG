using AI_Enemy;
using UnityEngine;

public class AI_Skeleton : MonoBehaviour
{
    public FSM_Enemy fsm_Skeleton;
    public BB_Skeleton board = new BB_Skeleton();
    // Start is called before the first frame update
    void Start()
    {
        fsm_Skeleton = new FSM_Enemy();
        fsm_Skeleton.Init(board);
        fsm_Skeleton.AddState(StateType.IDLE, new IdleState_Skeleton<BB_Skeleton>(board));
        fsm_Skeleton.AddState(StateType.MOVE, new MoveState_Skeleton<BB_Skeleton>(board));
        fsm_Skeleton.AddState(StateType.HIT, new HitState_Skeleton<BB_Skeleton>(board));
        fsm_Skeleton.SwitchState(StateType.IDLE, fsm_Skeleton, board);
    }

    // Update is called once per frame
    void Update()
    {
        fsm_Skeleton.OnUpdate(fsm_Skeleton, board);
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (var col in other.GetComponents<Collider>())
        {
            if (col.gameObject.tag == "Weapon")
            {
                fsm_Skeleton.SwitchState(StateType.HIT, fsm_Skeleton, board);
            }
        }
    }
}
