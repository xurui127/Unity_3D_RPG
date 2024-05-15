using AI_Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransition
{
    IState State { get; }
    IPredicate Predicate { get; }
}
