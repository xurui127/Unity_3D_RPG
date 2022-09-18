using UnityEngine;

public class AnimStateMachine : StateMachineBehaviour 
{
    AnimatorStateInfo lastStateInfo;
    private bool isInLastTransation;
    private bool isInCurTransation;
 

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isInCurTransation = animator.IsInTransition(layerIndex);
        //Cast the end Animation
        if (!isInLastTransation)
        {
            if(stateInfo.normalizedTime % 1.0 < lastStateInfo.normalizedTime %1.0)
            {
                
            }
        }
        // Cast the start of Animation
        if (isInCurTransation && !isInLastTransation)
        {
            
        }
        // Caset the first end of Animation
        if (!isInCurTransation && isInLastTransation)
        {
            
        }
    }



}
