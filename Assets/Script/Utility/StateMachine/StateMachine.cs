using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace FinitStateMachine
{   
    public enum StateType
    {
        IDLE,
        MOVE,
        COMBO,
        ATTACK,
        HIT,
        TUANT,
        DEAD,
    } 
   
    [Serializable]
    public class StateMachine
    {
        public  IState curState;
        public StateMachine fSM;
        public Dictionary<StateType, IState> states;
        public Dictionary<StateType, List<IState>> subStates;
        public BlackBoard board;
        public virtual void Init(BlackBoard board)
        {
 
            states = new Dictionary<StateType, IState>();
            subStates = new Dictionary<StateType, List<IState>>();
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

        public void SwitchState(StateType stateType , StateMachine stateMachine,BlackBoard board)
        {
            if (!states.ContainsKey(stateType))
            {
                Debug.Log(stateType.ToString() + " is not in the Dictionary !");
                return;
            }
            if(curState != null)
            {
                curState.OnExit(stateMachine);
            }
            curState = states[stateType];
            curState.OnEnter(stateMachine);
        }
        public void AddSubState(StateType stateType, IState state)
        {
            if (subStates.TryGetValue(stateType, out List<IState> subStateList))
            {
                if (subStateList.Contains(state))
                {
                    Debug.Log(state.ToString() + " is already in the list");
                    return;
                }

                subStateList.Add(state);
            }
            else
            {
                subStateList = new List<IState>();
                subStateList.Add(state);
                subStates[stateType] = subStateList;
            }
        }
        public void SwitchSubState(StateType stateType, StateMachine stateMachine, BlackBoard board, int index)
        {
            if (!subStates.TryGetValue(stateType, out List<IState> subStateList))
            {
                Debug.Log(stateType.ToString() + " is not in the Dictionary !");
                return;
            }

            if (curState != null)
            {
                curState.OnExit(stateMachine);
            }

            curState = subStateList[index];
            curState.OnEnter(stateMachine);
        }
        public virtual void OnUpdate(StateMachine stateMachine,BlackBoard board)
        {
            if (curState != null)
            {
                curState.OnCheck(stateMachine);

                curState.OnUpdate(stateMachine);
            }
            else
            {
                Debug.Log("CurState is NUll");
            }
        }
        
    }
}
