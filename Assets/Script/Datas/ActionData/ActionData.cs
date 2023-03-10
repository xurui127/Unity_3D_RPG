using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionData
{
    public enum ActionDuritionType
    {
        ACTIONBEGIN,
        ACTIONEND,
        ATTACKBEGIN,
        ATTACKEND,
    }
    public delegate void Notify();

}
