using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI_Enemy
{
    [Serializable]
    public class BlackBoard
    {
        //public  AnimController anim;
        public  NavMeshAgent agent;
        public  GameObject target;
    }
}