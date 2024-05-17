using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncPredicate : IPredicate
{
    private Func<bool> func;
    public FuncPredicate(Func<bool> func)
    {
        this.func = func;
    }
    public bool Evaluate()
    {
        return func.Invoke();
    }
}
