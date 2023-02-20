using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.UI;

public abstract class AnimController : MonoBehaviour
{
    protected Animator anim;
    protected AnimatorStateInfo curAnimInfo;


    protected int attackCount = 1;
    #region System

    //Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();

    }
    #endregion
    #region Animations Function
    public void SetAnimation(string paraName)
    {
        anim.SetTrigger(paraName);
    }
    public void SetAnimation(string paraName, float para)
    {
        anim.SetFloat(paraName, para);
    }
    #endregion

    public abstract  void OnMove(float speed);

    public abstract void OnAttack();
    protected abstract void Dead();
}
