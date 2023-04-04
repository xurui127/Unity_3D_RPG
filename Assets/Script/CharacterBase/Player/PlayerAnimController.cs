using UnityEngine;
using UnityEngine.Events;
using SO_PlayerPreTxt;
using Utility;
using PlayerAnimInfo;
using UnityExtension;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting.Antlr3.Runtime;

public class PlayerAnimController : AnimController
{

    [SerializeField] private PlayerAnimPreTxt_SO animpPreTxts;
    [Range(0f, 1f)]
    [SerializeField] private float comboCancletime;

    PlayerStateMachine playerStateMachine;

    UnityAction AnimDone;

    private GameObject weapon;
    private WeaponHaddler curWeapon;

    public bool IsBusy { get; private set; }

    //private bool isBusy => (!curAnimInfo.IsName(animpPreTxts.preTxt[0]) ? true : false);
    //public bool IsBusy => isBusy;
   


    protected override void Start()
    {
        base.Start();
        playerStateMachine = anim.GetBehaviour<PlayerStateMachine>();
        weapon = GameObjectFinder.FindChild(this.gameObject, "sword01");
        if (weapon != null)
        {
            curWeapon = weapon.GetComponent<WeaponHaddler>();
        }

    }
    private void SetAnimation(string paraName, UnityAction currentAnimBeginNotify, UnityAction currentAnimEndNotify , UnityAction currentAnimDoneNotify)
    {
        SetAnimation(paraName);
        AnimDone = currentAnimDoneNotify;
        playerStateMachine.ClearNotify();
        playerStateMachine.RegisterNotity(NotityState.OnNotifyBegin, currentAnimBeginNotify);
        playerStateMachine.RegisterNotity(NotityState.OnNotifyEnd, () =>
        {
            this.InvokeFromNextFrame(() =>
            {
                playerStateMachine.RegisterNotity(NotityState.OnNotifyEnd,currentAnimEndNotify);
            });
        });
       
    }

    public void AnimEventDone()
    {
        AnimDone();
    }
    #region Combo Anim Haddlers

    private void AttackCount()
    {
        if (animpPreTxts.currentAttackIndex > animpPreTxts.maxAttackIndex)
        {
            animpPreTxts.currentAttackIndex = animpPreTxts.minAtttackIndex;
        }
    }


    #endregion
    #region Behaviours Haddlers 
    public override void OnMove(float speed)
    {
        SetAnimation(animpPreTxts.moveTxt, speed);
    }
    public override void OnAttack()
    {
        CastAttack();
    }
   private void CastAttack()
    {
        if (IsBusy)
        {
            return;
        }
        AttackCount();
        SetAnimation(animpPreTxts.attackTxt + animpPreTxts.currentAttackIndex.ToString(), OnAttackBegin,OnAttackEnd, OnAttackDone);
    }
    private void OnAttackBegin()
    {
        animpPreTxts.currentAttackIndex++;
        IsBusy = true;
    }
  
    private void OnAttackEnd()
    {
        animpPreTxts.currentAttackIndex = animpPreTxts.minAtttackIndex;
    }
    private void OnAttackDone()
    {
        IsBusy = false;
        Debug.Log("IN done");
    }

    public void RollHaddler()
    {

        SetAnimation(animpPreTxts.rollTxt);

    }
    public void SprintHaddler()
    {
        SetAnimation(animpPreTxts.sprintTxt);
    }
    public override void GetHit()
    {

    }
    protected override void Dead()
    {

    }
    public void StartColldier()
    {
        curWeapon.StartCollider.Invoke();
    }
    #endregion

}
//public void ComboHaddler()
//{

//    curAnimInfo = anim.GetCurrentAnimatorStateInfo(0);
//    if (curAnimInfo.IsName(animpPreTxts.attackPreAnimTxt + attackCount.ToString()) && curAnimInfo.normalizedTime < 1f)
//    {
//        curWeapon.EnableVFX();
//    }
//    if (LastAnimInfo.normalizedTime >= 1f)
//    {
//        curWeapon.DisableVFX();
//    }
//    if (curAnimInfo.IsName(animpPreTxts.attackPreAnimTxt + attackCount.ToString()) && curAnimInfo.normalizedTime >= 0.5f && curAnimInfo.normalizedTime <= 1f)
//    {
//        attackCount++;
//        HitCounting.Invoke();
//    }
//    if (curAnimInfo.IsName(animpPreTxts.idleTxt) || curAnimInfo.IsName(animpPreTxts.rollTxt))
//    {
//        if (curAnimInfo.normalizedTime >= comboCancletime)
//        {
//            attackCount = 1;
//        }
//    }
//    lastAnimInfo = curAnimInfo;
//}