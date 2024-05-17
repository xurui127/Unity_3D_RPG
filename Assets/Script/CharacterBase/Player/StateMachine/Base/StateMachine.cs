using System;
using System.Collections;
using System.Collections.Generic;
using AI_Enemy;
using UnityEngine;
using UnityEngine.XR;

public class StateMachine
{
    private StateNode current;
    private Dictionary<Type, StateNode> nodes = new();
    private HashSet<ITransition> anyTransitions = new();

    public void Update()
    {
        var transition = GetTransition();
        if (transition != null)
        {
            ChangeState(transition.State);
        }
        current.state?.OnEnter();
    }
    public void FixedUpdate()
    {
        current.state?.OnFixedUpdate();
    }

    public void SetState(IState state)
    {
        current = nodes[state.GetType()];
        current.state.OnEnter();
    }

    public void AddTransition(IState from, IState to, IPredicate condition)
    {
        GetOrAddTransition(from).AddTransition(GetOrAddTransition(to).state, condition);
    }
    public void AddAnyTransition(IState to,IPredicate condition)
    {
        anyTransitions.Add(new Transition(to, condition));
    }
    private StateNode GetOrAddTransition(IState state)
    {
        var node = nodes.GetValueOrDefault(state.GetType());
        if (node == null)
        {
            node = new StateNode(state);
            nodes.Add(node.GetType(), node);
        }

        return node;
    }
    private void ChangeState(IState state)
    {
        if (current.state == state)
        {
            return;
        }
        var previousState = current.state;
        var nextState = nodes[state.GetType()].state;
        previousState?.OnExit();
        nextState?.OnEnter();
        current = nodes[state.GetType()];
    }
    private ITransition GetTransition()
    {
        foreach (var transition in anyTransitions)
        {
            if (transition.Predicate.Evaluate())
            {
                return transition;
            }
        }
        foreach (var transition in current.transitions)
        {
            if (transition.Predicate.Evaluate())
            {
                return transition;
            }
        }
        return null;
    }
}