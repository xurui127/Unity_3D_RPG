using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateMachine : StateMachineBehaviour
{
    bool isInCurTranstion;
    bool isInLastTranstion;
    AnimatorStateInfo lastAnimStateInfo;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //isInCurTranstion = animator.IsInTransition(layerIndex);

        //if (isInCurTranstion)
        //{
        //    if (stateInfo.normalizedTime % 1.0f < lastAnimStateInfo.normalizedTime % 1.0f)
        //    {
        //        Debug.Log("Begin");
        //    }
        //}
        //if (isInCurTranstion && isInLastTranstion)
        //{
        //    Debug.Log("1");
        //}
        //if (isInCurTranstion && !isInLastTranstion)
        //{

        //}
        //isInLastTranstion = isInCurTranstion;
        //lastAnimStateInfo = stateInfo;
        
    }


}
