using AI_Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : ITransition
{
    public IState State { get; }
    public IPredicate Predicate { get; }

    public Transition(IState state, IPredicate predicate)
    {
        State = state;
        Predicate = predicate;
    }
}
