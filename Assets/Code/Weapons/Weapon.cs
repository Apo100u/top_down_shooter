using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float minDamage;
    [SerializeField] protected float maxDamage;
    [SerializeField] protected float cooldown;
    [SerializeField] protected float range;

    private float lastUseTime = 0f;

    public virtual void TryUse()
    {
        if (Time.time > lastUseTime + cooldown)
        {
            OnSuccessfulUse();
            lastUseTime = Time.time;
        }
    }

    public abstract void OnSuccessfulUse();
}