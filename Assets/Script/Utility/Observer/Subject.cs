using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
   public void AddObserver() { }
   public void RemoveObserver() { }
   private void NotifyObserver() { }
}
