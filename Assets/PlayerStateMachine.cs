using PlayerAnimInfo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStateMachine : StateMachineBehaviour
{
    private AnimatorStateInfo lastStateInfo;
    private bool inLastTransition;
    private bool inCurTransition;

    private Dictionary<NotityState, List<UnityAction>> notifyList = new Dictionary<NotityState, List<UnityAction>>();

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inCurTransition = animator.IsInTransition(layerIndex);

        // Cast curent animtion end
        if (!inCurTransition)
        {

            if (stateInfo.normalizedTime < lastStateInfo.normalizedTime)
            {
                TriggerNotify(NotityState.OnNotifyEnd);
            }


            inLastTransition = inCurTransition;
            lastStateInfo = stateInfo;
        }
        //Cast from current animtion begin
        if (inCurTransition && !inLastTransition)
        {
            TriggerNotify(NotityState.OnNotifyBegin);
        }
        //Cast from last animtion end
        if (!inCurTransition && inLastTransition)
        {
            TriggerNotify(NotityState.OnNotifyEnd);
        }
        
       
       
    }

    public void RegisterNotity(NotityState stateName, UnityAction notify)
    {
        List<UnityAction> actionList;
        if (notifyList.ContainsKey(stateName))
        {
            actionList = notifyList[stateName];
            actionList.Add(notify);
        }
        else
        {
            actionList = new List<UnityAction>();
            actionList.Add(notify);
            notifyList.Add(stateName, actionList);
        }
    }
    
    public void TriggerNotify(NotityState stateName)
    {
        if (notifyList.ContainsKey(stateName))
        {
            var actionList = notifyList[stateName];
            while (notifyList[stateName].Count > 0)
            {
                var notity = actionList[0];
                actionList.Remove(notity);
                notity();
            }
        }
       
    }
    public void ClearNotify()
    {
        if (notifyList == null)
        {
            return;
        }
        List<UnityAction> actionList;
        for(var i = NotityState.OnNotifyBegin; i<= NotityState.OnNotifyEnd; i++)
        {
            if (notifyList.ContainsKey(i))
            {
                actionList = notifyList[i];
                actionList.Clear();
            }
        }

    }
}

