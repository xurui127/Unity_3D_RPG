using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace AI_Enemy
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
        void OnUpdate();
        void OnFixedUpdate();
        void OnCheck();

    }

    
}