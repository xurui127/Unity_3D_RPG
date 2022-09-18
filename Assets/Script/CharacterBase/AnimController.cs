using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class AnimController : MonoBehaviour
{
    Animator anim;
    int hitCount = 0;
    private AnimatorStateInfo animInfo;
    private string attackPreAnimTxt = "SwordAndShield_Combo0";
    private string rollPreAnimTxt = "Roll_Battle_SwordAndShield";
    private string attackPreTxt = "attack ";
    private string idleTxt = "Locomotion";
    private string rollTxt = "roll";
    string[] preTxt = { "Locomotion", "SwordAndShield_Combo01", "SwordAndShield_Combo02", "SwordAndShield_Combo03" };
    private bool isBusy;
    public bool IsBusy => isBusy;
    #region System

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ComboHaddler();
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
    public void ComboHaddler()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (!animInfo.IsName(idleTxt) && animInfo.normalizedTime >= 1.0f)
        {
            hitCount = 0;
            isBusy = false;
        }
        else if  (animInfo.IsName(idleTxt))
        {
            isBusy = false;

        }
    }
    public void AttackHaddler()
    {

        if (animInfo.IsName(idleTxt) && hitCount == 0)
        {
            hitCount = 1;
            SetAnimation(attackPreTxt + hitCount.ToString());
        }
        else if (animInfo.IsName(attackPreAnimTxt + hitCount.ToString()) && hitCount == 1 && animInfo.normalizedTime > 0.5f)
        {
            hitCount = 2;
            SetAnimation(attackPreTxt + hitCount.ToString());
        }
        else if (animInfo.IsName(attackPreAnimTxt + hitCount.ToString()) && hitCount == 2 && animInfo.normalizedTime > 0.5f)
        {
            hitCount = 3;
            SetAnimation(attackPreTxt + hitCount.ToString());
        }
    }

    public void RollHaddler()
    {
      
            SetAnimation(rollTxt);
        
    }
    public void Busy()
    {
        isBusy = true;
    }
    #endregion
}
