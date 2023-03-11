using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public abstract class AnimController : MonoBehaviour
{
    protected Animator anim;
    public Animator animIns { get { return anim; } }
    public AnimatorStateInfo curAnimInfo;
    public AnimatorStateInfo CurAnimInfo { get { return curAnimInfo; } set => curAnimInfo = value; }

    public AnimatorStateInfo lastAnimInfo;
    public AnimatorStateInfo LastAnimInfo { get => lastAnimInfo; set => lastAnimInfo = value; }

    //public delegate void NotifyBegin();

    protected int attackCount = 1;
    #region System

    //Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();

    }
    #endregion
    #region Animations Function
    protected void SetAnimation(string paraName)
    {
        anim.SetTrigger(paraName);
    }
    protected void SetAnimation(string paraName, float para)
    {
        anim.SetFloat(paraName, para);
    }

    #endregion
    public abstract  void OnMove(float speed);

    public abstract void OnAttack();
    protected abstract void Dead();
    public abstract void GetHit();
   

}
