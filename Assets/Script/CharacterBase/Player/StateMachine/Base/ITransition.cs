using AI_Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransition 
{
   public IState State { get; }
   public IPredicate Predicate { get; }

}
