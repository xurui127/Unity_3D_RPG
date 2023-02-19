using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.UI;

public class AnimController : MonoBehaviour
{
    protected Animator anim;
    protected AnimatorStateInfo curAnimInfo;

    #region System

    //Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

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

}
