using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SO_PlayerPreTxt;
using Unity.VisualScripting;
using Utility;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Build;

public class PlayerAnimController : AnimController
{

    [SerializeField] private PlayerAnimPreTxt_SO animpPreTxts;
    [Range(0f, 1f)]
    [SerializeField] private float comboCancletime;
    
    
    
    private GameObject weapon;
    private WeaponHaddler curWeapon;
    private bool isBusy => (!curAnimInfo.IsName(animpPreTxts.preTxt[0]) ? true : false);
    public bool IsBusy => isBusy;
    private UnityEvent HitCounting;
    private UnityEvent CheckLastAnim;
  

    protected override void Start()
    {
        base.Start();
        if (HitCounting == null)
        {
            HitCounting = new UnityEvent();
        }
        HitCounting.AddListener(CheckHitCount);
        if (CheckLastAnim == null)
        {
            CheckLastAnim = new UnityEvent();
        }
        weapon = GameObjectFinder.FindChild(this.gameObject, "sword01");
        if(weapon != null)
        {
            curWeapon = weapon.GetComponent<WeaponHaddler>();
        }
    }
    private void Update()
    {
        ComboHaddler();
        //Debug.Log(attackPreAnimTxt + hitCount.ToString());
    }

    #region Combo Anim Haddlers
    public void ComboHaddler()
    {

        curAnimInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (curAnimInfo.IsName(animpPreTxts.attackPreAnimTxt + attackCount.ToString())&& curAnimInfo.normalizedTime < 1f)
        {
            curWeapon.EnableVFX();
        }
        if (LastAnimInfo.normalizedTime >= 1f)
        {
            curWeapon.DisableVFX();
        }
        if (curAnimInfo.IsName(animpPreTxts.attackPreAnimTxt + attackCount.ToString()) && curAnimInfo.normalizedTime >= 0.5f && curAnimInfo.normalizedTime <= 1f)
        {
            attackCount++;
            HitCounting.Invoke();
        }
        if (curAnimInfo.IsName(animpPreTxts.idleTxt) || curAnimInfo.IsName(animpPreTxts.rollTxt))
        {
            if (curAnimInfo.normalizedTime >= comboCancletime)
            {
                attackCount = 1;
            }
        }
        lastAnimInfo = curAnimInfo;
    }
    private void CheckHitCount()
    {
        if (attackCount > 3)
        {
            attackCount = 1;
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
        SetAnimation(animpPreTxts.attackTxt + attackCount.ToString());
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
