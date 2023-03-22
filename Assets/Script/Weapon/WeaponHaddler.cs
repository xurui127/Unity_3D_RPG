
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using Utility;

public class WeaponHaddler : MonoBehaviour
{

    public Collider collider;
    private float colliderWaitingTime = 0.1f;
    [HideInInspector]
    public UnityEvent StartCollider = new UnityEvent();
    public  GameObject swordVFX;
    public GameObject currentVFx;


    public void Start()
    {

        collider = GetComponent<BoxCollider>();
        if (StartCollider != null)
        {
            StartCollider.AddListener(OnColliderStart);
        }
       
        CombatEventManager.Instance.AddEventListener(NPCEventType.AttackBegin.ToString(), GenerateVfX);
        CombatEventManager.Instance.AddEventListener(NPCEventType.AttackBegin.ToString(), DestroyVFX);
    }

   public void InitVFX()
    {
        Instantiate(swordVFX, transform).SetActive(true);
      
    }
    public void GenerateVfX()
    {
        InitVFX();
    }

    public void DestroyVFX()
    {
        //var cur = GameObjectFinder.FindChild(this.gameObject, "Splash01");
        //Debug.Log(cur.name);
        //Destroy(cur);
        //var cur = transform.Find(swordVFX.name);
        //Destroy(cur);
    }
    public void EnableVFX()
    {
        swordVFX.SetActive(true);
    }
    public void DisableVFX()
    {
        swordVFX.SetActive(false);
    }
    public void OnAnimStart()
    {

    }
    public void OnColliderStart()
    {
        StopAllCoroutines();
        StartCoroutine(ColliderControl());
    }
    private IEnumerator ColliderControl()
    {
        collider.enabled = true;
        yield return new WaitForSeconds(colliderWaitingTime);
        collider.enabled = false;
        yield return null;
    }
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("in");
        collider.enabled = false;
        //foreach (var col in other.GetComponentsInChildren<Collider>())
        //{
        //    if (col.gameObject.tag == "EnemyDamagable")
        //    {
        //        var target = col.GetComponentInParent<AnimController>();
        //        target.GetHit();

        //    }
        //}
    }
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            DestroyVFX();
            //Debug.Log("In 1");
            //CombatEventManager.Instance.TriggerEventListener(NPCEventType.AttackBegin.ToString());
            //EnableVFX();
        }
        //if (Input.GetKeyDown("2"))
        //{
        //    Debug.Log("In 2");

        //    CombatEventManager.Instance.TriggerEventListener(NPCEventType.AttackEnd.ToString());
        //}
    }

}
