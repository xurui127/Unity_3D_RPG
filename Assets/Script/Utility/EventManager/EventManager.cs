using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public enum NPCEventType
{
    AttackBegin,
    AttackEnd,
}
public interface IEvent { }
public class EventInfo : IEvent
{
    public UnityAction actions;
    public EventInfo( UnityAction action)
    {
        this.actions += action;
    }
}
public class EventInfo<T> : IEvent
{
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action)
    {
        this.actions += action;
    }
}

public class EventManager : Singleton<EventManager>
{
    private Dictionary<string, IEvent> eventList;

 

    protected void Init()
    { 
        eventList = new Dictionary<string, IEvent>();
    }

    //Add Event

    public void AddEventListener(string name, UnityAction action)
    {
        if (eventList.ContainsKey(name))
        {
            (eventList[name] as EventInfo).actions += action;
        }
        else
        {
            eventList.Add(name,new EventInfo( action));
        }
    }
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventList.ContainsKey(name))
        {
            (eventList[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventList.Add(name, new EventInfo<T>(action));
        }
    }
    //Remove Event
    public void RemoveEventListner(string name,UnityAction action)
    {
        if (eventList.ContainsKey(name))
        {
            (eventList[name] as EventInfo).actions -= action;
        }
        else
        {
            Debug.Log("no action in the list");
        }
    }
    public void RemoveEventListner<T>(string name,UnityAction<T> action)
    {
        if (eventList.ContainsKey(name))
        {
            (eventList[name] as EventInfo<T>).actions -= action;
        }
        else
        {
            Debug.Log("no action in the list");
        }
    }
    //Trigger Event
    public void TriggerEventListener(string name)
    {
        if (eventList.ContainsKey(name))
        {
            Debug.Log("Called");
            (eventList[name] as EventInfo).actions?.Invoke();
        }
    } 
    public void TriggerEventListener<T>(string name , T info)
    {
        if (eventList.ContainsKey(name))
        {
            Debug.Log("Called");
            (eventList[name] as EventInfo<T>).actions?.Invoke(info);
        }
    }
    //Clear Event

    public void ClearEvent()
    {
        eventList.Clear();
    }
}
