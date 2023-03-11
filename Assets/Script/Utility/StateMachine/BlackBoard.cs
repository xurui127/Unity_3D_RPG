using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FinitStateMachine
{
    [Serializable]
    public class BlackBoard
    {
        public  Animator anim;
        public  NavMeshAgent agent;
        public  GameObject target;
    }
}