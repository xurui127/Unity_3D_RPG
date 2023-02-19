using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimController : AnimController
{
    int hitCount = 1;
    private string attackPreAnimTxt = "SwordAndShield_Combo0";
    private string rollPreAnimTxt = "Roll_Battle_SwordAndShield";
    private string attackPreTxt = "attack ";
    private string idleTxt = "Locomotion";
    private string rollTxt = "roll";
    private string sprintTxt = "sprint";
    string[] preTxt = { "Locomotion", "SwordAndShield_Combo01", "SwordAndShield_Combo02", "SwordAndShield_Combo03" };
    private bool isBusy => (!curAnimInfo.IsName(preTxt[0]) ? true : false);
    public bool IsBusy => isBusy;
    private UnityEvent HitCounting;
    private UnityEvent CheckLastAnim;
    [Range(0f, 1f)]
    [SerializeField] private float comboCancletime;

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


        if (curAnimInfo.IsName(attackPreAnimTxt + hitCount.ToString()) && curAnimInfo.normalizedTime >= 0.5f && curAnimInfo.normalizedTime <= 1f)
        {

            hitCount++;
            HitCounting.Invoke();
        }
        if (curAnimInfo.IsName(idleTxt) || curAnimInfo.IsName(rollTxt))
        {
            if (curAnimInfo.normalizedTime >= comboCancletime)
            {
                hitCount = 1;
            }
        }


    }
    private void CheckHitCount()
    {
        if (hitCount > 3)
        {
            hitCount = 1;
        }
    }

    public void AttackHaddler()
    {
        SetAnimation(attackPreTxt + hitCount.ToString());
    }
    #endregion
    #region Action Haddlers 
    public void RollHaddler()
    {

        SetAnimation(rollTxt);

    }
    public void SprintHaddler()
    {
        SetAnimation(sprintTxt);
    }
    #endregion
}
