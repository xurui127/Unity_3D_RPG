using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FinitStateMachine;
using UnityEngine.AI;
using System;
using UnityEngine.UI;

[Serializable]
public class BB_Skeleton : BlackBoard
{
    public Animator anim;
    public NavMeshAgent agent;
    public GameObject target;
    public SkeletonAnimController animController;
}
