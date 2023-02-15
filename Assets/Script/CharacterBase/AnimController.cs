using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.UI;

public class AnimController : MonoBehaviour
{
    Animator anim;
    int hitCount = 1;
    private AnimatorStateInfo curAnimInfo;
    private AnimatorStateInfo lastAnimInfo;
    private AnimatorStateInfo preAnimInfo;
    private string attackPreAnimTxt = "SwordAndShield_Combo0";
    private string rollPreAnimTxt = "Roll_Battle_SwordAndShield";
    private string attackPreTxt = "attack ";
    private string idleTxt = "Locomotion";
    private string rollTxt = "roll";
    private string sprintTxt = "sprint";
    string[] preTxt = { "Locomotion","SwordAndShield_Combo01", "SwordAndShield_Combo02", "SwordAndShield_Combo03" };
    private bool isBusy => (!curAnimInfo.IsName(preTxt[0]) ? true: false);
    public bool IsBusy => isBusy;
    private UnityEvent HitCounting;
    private UnityEvent ChechLastAnim;
    [Range(0f, 1f)]
    [SerializeField] private float comboCancletime;
    #region System

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (HitCounting == null)
        {
            HitCounting = new UnityEvent();
        }
        HitCounting.AddListener(CheckHitCount);
        if (ChechLastAnim == null)
        {
            ChechLastAnim = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ComboHaddler();
       // Debug.Log(attackPreAnimTxt + hitCount.ToString());
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
    #region Combo Anim Haddlers
    public void ComboHaddler()
    {
       
        curAnimInfo = anim.GetCurrentAnimatorStateInfo(0);

        
        if(curAnimInfo.IsName(attackPreAnimTxt + hitCount.ToString()) && curAnimInfo.normalizedTime >= 0.5f && curAnimInfo.normalizedTime <= 1f)
        {
           
            hitCount++;
            HitCounting.Invoke();
            lastAnimInfo = curAnimInfo;
        }
        if (curAnimInfo.IsName(idleTxt) || curAnimInfo.IsName(rollTxt) )
        {
            if ( curAnimInfo.normalizedTime >= comboCancletime)
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
