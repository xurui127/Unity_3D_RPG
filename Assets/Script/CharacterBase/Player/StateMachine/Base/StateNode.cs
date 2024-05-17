using AI_Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNode 
{
   public IState state;
   public HashSet<ITransition> transitions;

    public StateNode(IState state)
    {
        this.state = state;
        transitions = new HashSet<ITransition>();
    }

    public void AddTransition(IState to,IPredicate condition)
    {
        transitions.Add(new Transition(to, condition));
    }
}
