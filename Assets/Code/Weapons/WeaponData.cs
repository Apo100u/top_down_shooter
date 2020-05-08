using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "New Weapon Data", order = 1)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private float minDamage;
    public float MinDamage { get { return minDamage; } }

    [SerializeField] private float maxDamage;
    public float MaxDamage { get { return maxDamage; } }

    [SerializeField] private float cooldown;
    public float Cooldown { get { return cooldown; } }
}