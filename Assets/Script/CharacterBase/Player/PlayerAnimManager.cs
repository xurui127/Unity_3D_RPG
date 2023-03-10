using Newtonsoft.Json.Serialization;
using SO_PlayerPreTxt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActionData;

public class PlayerAnimManager:EventManager<PlayerAnimManager>
{
    [SerializeField] private PlayerAnimPreTxt_SO animpPreTxts;
    protected Animator anim;
    public Animator animIns { get { return anim; } }
    public AnimatorStateInfo curAnimInfo;
    public AnimatorStateInfo CurAnimInfo { get { return curAnimInfo; } set => curAnimInfo = value; }

    public AnimatorStateInfo lastAnimInfo;
    public AnimatorStateInfo LastAnimInfo { get => lastAnimInfo; set => lastAnimInfo = value; }

    public bool isBusy;
    public bool IsBusy { get { return isBusy; } set { isBusy = value; } }

    [SerializeField] private float comboCancletime;
    public int attackCount = 1;
    protected override void Awake()
    {
        //shouldDestroy = false;
        //base.Awake();
        Init();
    }
    private void Start()
    {
        instance.AddAction(ActionDuritionType.ACTIONBEGIN, ActiveBusy);
        instance.AddAction(ActionDuritionType.ACTIONEND, DeactiveBusy);
        instance.AddAction(ActionDuritionType.ATTACKBEGIN, UpdateAttackCount);

    }
    private void OnDisable()
    {
        instance.RemoveAction(ActionDuritionType.ACTIONBEGIN, ActiveBusy);
        instance.RemoveAction(ActionDuritionType.ACTIONEND, DeactiveBusy);
        instance.RemoveAction(ActionDuritionType.ATTACKBEGIN, UpdateAttackCount);

    }
    private void PlayerComboHaddle()
    {
        curAnimInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (curAnimInfo.IsName(animpPreTxts.attackPreAnimTxt + attackCount.ToString()) && curAnimInfo.normalizedTime < 1f)
        {
            //curWeapon.EnableVFX();
        }
        if (LastAnimInfo.normalizedTime >= 1f)
        {
            //curWeapon.DisableVFX();
        }
        if (curAnimInfo.IsName(animpPreTxts.attackPreAnimTxt + attackCount.ToString()) && curAnimInfo.normalizedTime >= 0.5f && curAnimInfo.normalizedTime <= 1f)
        {
            attackCount++;
            //HitCounting.Invoke();
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
    private void UpdateAttackCount()
    {
        attackCount++;
        Debug.Log(attackCount);
        if (attackCount >= 3)
        {
            attackCount = 1;
        }
    }
    private void ActiveBusy()
    {
        isBusy = true;
       
    }
    private void DeactiveBusy()
    {
        isBusy = false;

    }
    //private void Start()
    //{
    //}
    //public void OnEnable()
    //{
    //    GetInstance().AddAction(ActionDuritionType.ATTACKBEGIN, Test);

    //}
    //private void OnDisable()
    //{
    //    GetInstance().RemoveAction(ActionDuritionType.ATTACKBEGIN, Test);
    //}
    //void Test()
    //{
    //    Debug.Log("Working");
    //}
}
