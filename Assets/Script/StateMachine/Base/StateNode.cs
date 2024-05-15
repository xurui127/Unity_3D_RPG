using AI_Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNode
{
    public IState state { get; }
    public HashSet<ITransition> transitions { get; }

    public StateNode(IState state)
    {
        this.state = state;
        transitions = new HashSet<ITransition>();
    }

    public void AddTransition(IState state,IPredicate condition)
    {
        transitions.Add(new Transition(state, condition));
    }

}
