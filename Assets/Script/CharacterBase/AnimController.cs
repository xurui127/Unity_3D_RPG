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
    private string attackPreTxt = "attack ";
    private string idleTxt = "Locomotion";
    string[] preTxt = { "Locomotion", "SwordAndShield_Combo01", "SwordAndShield_Combo02", "SwordAndShield_Combo03" };

    Dictionary<int,string> actions = new Dictionary<int,string>();
    #region
    private void Awake()
    {
        actions.Add(0, "Locomotion");
        actions.Add(1, "SwordAndShield_Combo01");
        actions.Add(2, "SwordAndShield_Combo02");
        actions.Add(3, "SwordAndShield_Combo03");

    }
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
        }
    }
    //private void AttackCondition(AnimatorStateInfo animInfo, string statePreText, string attackPreTxt, int hitCount , int index)
    //{
    //    if (animInfo.IsName(statePreText) && hitCount == index)
    //    {
    //        hitCount++;
    //        SetAnimation(attackPreTxt + hitCount.ToString());

    //    }
    //}
    public void AttackHaddler()
    {

        ComboHaddler();
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

        //AttackCondition(animInfo, actions[hitCount], attackPreTxt, hitCount, actions.ElementAt(hitCount).Key);
    }
   
    #endregion
}
