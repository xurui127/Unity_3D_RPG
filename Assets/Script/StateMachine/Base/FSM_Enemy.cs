using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Enemy
{
    public enum StateType
    {
        IDLE,
        MOVE,
        ATTACK,
        HIT,
        TUANT,
        DEAD,
    }
    [Serializable]
    public class FSM_Enemy
    {
        public IState curState;
        public Dictionary<StateType, IState> states;
        public BlackBoard board;
        public FSM_Enemy fSM;
        public void Init(BlackBoard board)
        {
            states = new Dictionary<StateType, IState>();
            this.board = board;
        }
        public void AddState(StateType stateType, IState state)
        {
            if (states.ContainsKey(stateType))
            {
                Debug.Log("State is already in Dictionary");
                return;
            }
            states.Add(stateType, state);
        }

        public void SwitchState(StateType stateType, FSM_Enemy fSM_Enemy, BlackBoard board)
        {
            if (!states.ContainsKey(stateType))
            {
                Debug.Log(stateType.ToString() + " is not in the Dictionary !");
                return;
            }
            if (curState != null)
            {
                curState.OnExit(fSM_Enemy);
            }
            curState = states[stateType];
            curState.OnEnter(fSM_Enemy);
        }

        public void OnUpdate(FSM_Enemy fSM_Enemy, BlackBoard board)
        {
            curState.OnCheck(fSM_Enemy);
            curState.OnUpdate(fSM_Enemy);
        }

    }
}
