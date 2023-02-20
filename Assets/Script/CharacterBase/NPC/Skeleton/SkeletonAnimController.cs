using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimController : AnimController
{
    private Animator anim;

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    public void OnMove()
    {
        
    }
}

