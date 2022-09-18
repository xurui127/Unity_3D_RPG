using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator anim;

    #region
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region Animations Function
    public void SetAnimation(string paraName)
    {
        anim.SetTrigger(paraName);
    }
    public void  SetAnimation(string paraName, float para)
    {
        anim.SetFloat(paraName, para);
    }


    #endregion
}
