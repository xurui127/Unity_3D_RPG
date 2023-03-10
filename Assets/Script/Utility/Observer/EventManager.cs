
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static ActionData;




public   class EventManager<T>: Singleton<T> where T:EventManager<T> 
{
    
    Dictionary<ActionDuritionType, UnityAction> Notifies = new Dictionary<ActionDuritionType, UnityAction>();
    public void AddAction(ActionDuritionType actionType, UnityAction notify) 
    {
        if (Notifies.ContainsKey(actionType))
        {
            Notifies[actionType] += notify;
            
        }
        else
        {
            Notifies.Add(actionType, notify);
        }
    }
    public void RemoveAction(ActionDuritionType actionType, UnityAction notify)
    {
        if (Notifies.ContainsKey(actionType))
        {
            Notifies[actionType] -= notify;
        }
    }
    public void TriggerAction(ActionDuritionType actionType)
    {
        if (Notifies[actionType] != null)
        {
        Notifies[actionType]?.Invoke();

        }
        else
        {
            Debug.Log(Notifies[actionType]);
        }
    } 
}
