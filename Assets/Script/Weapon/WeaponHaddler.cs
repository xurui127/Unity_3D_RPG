
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class WeaponHaddler : MonoBehaviour
{

    public Collider collider;
    private float colliderWaitingTime = 0.1f;
    [SerializeField]public GameObject swordVFX;
    [SerializeField]private WeaponSO weapon;
    [HideInInspector]
    public UnityEvent StartCollider = new UnityEvent();
    

    public void Start()
    {

        collider = GetComponent<BoxCollider>();
        if (StartCollider != null)
        {
            StartCollider.AddListener(OnColliderStart);
        }
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

}
