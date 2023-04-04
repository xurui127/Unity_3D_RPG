using UnityEngine;
using UnityEngine.Events;
using SO_PlayerPreTxt;
using Utility;
using PlayerAnimInfo;
using UnityExtension;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting;

public class PlayerAnimController : AnimController
{

    [SerializeField] private PlayerAnimPreTxt_SO animpPreTxts;
    [Range(0f, 1f)]
    [SerializeField] private float comboCancletime;

    PlayerStateMachine playerStateMachine;

    UnityAction AnimDone;

    private GameObject weapon;
    private WeaponHaddler curWeapon;
    private GameObject curVFX;

    public bool IsBusy { get; private set; }

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
    #region Behaviours Haddlers 
    #region Move Behaviour
    public override void OnMove(float speed)
    {
        SetAnimation(animpPreTxts.moveTxt, speed);
    }
    #endregion
    #region Attack Behaviour 
    // Called when Attack input clicked 
    public override void OnAttack()
    {
        CastAttack();
    }
    // Called when Attack input clicked 

    private void CastAttack()
    {
        if (IsBusy)
        {
            return;
        }
        AttackCount();
        SetAnimation(animpPreTxts.attackTxt + animpPreTxts.currentAttackIndex.ToString(), OnAttackBegin,OnAttackEnd, OnAttackDone);
    }
    // Reset AttackIndex
    private void AttackCount()
    {
        if (animpPreTxts.currentAttackIndex > animpPreTxts.maxAttackIndex)
        {
            animpPreTxts.currentAttackIndex = animpPreTxts.minAtttackIndex;
        }
    }
    // Attack Animation Start 
    private void OnAttackBegin()
    {

        animpPreTxts.currentAttackIndex++;
        IsBusy = true;
        // Current VFX Setting
        curVFX = PoolManager.Release(curWeapon.swordVFX, weapon.transform.position);
        curVFX.transform.SetParent(curWeapon.transform);
    }

    // Attack Animation finish without any input 
    private void OnAttackEnd()
    {
        animpPreTxts.currentAttackIndex = animpPreTxts.minAtttackIndex;
    }
    // Attack animation Finish
    private void OnAttackDone()
    {
        IsBusy = false;
        // If Attack animtion finish Destroy Current VFX
        Destroy(curVFX);
    }
    #endregion
    #region Roll Behaviour
    public void RollHaddler()
    {

        SetAnimation(animpPreTxts.rollTxt);

    }
    #endregion
    #region Sprint Behaviour
    public void SprintHaddler()
    {
        SetAnimation(animpPreTxts.sprintTxt);
    }
    #endregion
    #region Hit Behaviour
    public override void GetHit()
    {

    }
    #endregion
    #region Death Behaviour
    protected override void Dead()
    {

    }
    #endregion
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