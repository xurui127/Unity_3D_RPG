using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnimStateMachine : StateMachineBehaviour
{
    AnimatorStateInfo curStateInfo;
    AnimatorStateInfo lastStateInfo;
    bool curTransation;
    bool lastTrancsation;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        curStateInfo = stateInfo;
        curTransation = animator.IsInTransition(layerIndex);
        if (!curTransation && lastTrancsation) // Cast animation begin
        {
          
        }
        if (curTransation) // cast last animation end
        {
            if (curStateInfo.normalizedTime % 1.0 < lastStateInfo.normalizedTime % 1.0f)
            {
               
           
            }
        }
        lastStateInfo = curStateInfo;
        lastTrancsation = curTransation;
    }


}
