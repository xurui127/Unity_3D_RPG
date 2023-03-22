using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEventManager : EventManager
{
    protected override void Awake()
    {
        base.Awake();
        Init();
    }


}
