using UnityEngine;

[CreateAssetMenu(fileName = "SwordWeapon", menuName = "Weapon/Sword", order = 1)]
public class WeaponSO : ScriptableObject
{
    [Header("Compoments")]
    public GameObject effect;

    [Space][Space][Space]
    [Header("Attack Datas")]
    public int AttackIndex;
    public float[] AttackDMG;

}
