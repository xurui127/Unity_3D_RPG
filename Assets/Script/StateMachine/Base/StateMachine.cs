using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using AI_Enemy;

public class StateMachine
{
    private StateNode currentState;
    private Dictionary<Type, StateNode> nodes = new();
    private HashSet<ITransition> anyTransition = new();


    public void OnUpdate()
    {
        var transition = GetTransition();
        if (transition != null) 
        {
            ChangeState(transition.State);
        }

        currentState.state?.OnUpdate();
    }
    public void OnFixedUpdate()
    {
        currentState.state?.FixedUpdate();
    }
    public void SetState(IState state) 
    {
        currentState = nodes[state.GetType()];
        currentState.state?.OnEnter();
    }

    public void ChangeState(IState state)
    {
        if (state == currentState.state)
        {
            return;
        }
        var previousState = currentState.state;
        var nextState = nodes[state.GetType()].state;

        previousState?.OnExit();
        nextState?.OnEnter();

        currentState = nodes[state.GetType()];
    }
    private ITransition GetTransition()
    {
        foreach (var transition in anyTransition)
        {
            if (transition.Predicate.Evaluate())
            {
                return transition;
            }
          
        }
        foreach (var transition in currentState.transitions)
        {
            if (transition.Predicate.Evaluate())
            {
                return transition;
            }
        }
        return null;
    }

    public void AddTransition(IState from, IState to,IPredicate condition)
    {
        GetOrAddNode(from).AddTransition(GetOrAddNode(to).state, condition);
    }
    private StateNode GetOrAddNode(IState state)
    {
        var node = nodes.GetValueOrDefault(state.GetType());

        if (node == null)
        {
            node = new StateNode(state);
            nodes.Add(state.GetType(), node);
        }

        return node;
    }
}
