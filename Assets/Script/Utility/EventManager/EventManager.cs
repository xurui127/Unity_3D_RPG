using PlayerAnimInfo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class EventManager : Singleton<EventManager>
{
    Dictionary<NotityState,UnityAction> notifyList;

    protected  void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        notifyList = new Dictionary<NotityState, UnityAction>();
    }

    public void AddListener(NotityState state,UnityAction action)
    {
        if (notifyList.ContainsKey(state))
        {
            notifyList[state] += action;
        }
        else
        {
            notifyList.Add(state, action);
        }
    }
    public void RemoveListener(NotityState state, UnityAction action)
    {
        if (notifyList.ContainsKey(state))
        {
            notifyList[state] -= action;
        }
        else
        {
            Debug.Log("List do not have this state");
        }
    }
    public void TriggerListener(NotityState state)
    {
        if (notifyList.ContainsKey(state))
        {
            notifyList[state]?.Invoke();
        }
    }

    public void ClearAllListeners()
    {
        notifyList.Clear();
    }
}
