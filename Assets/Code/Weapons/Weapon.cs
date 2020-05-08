using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData data;

    private float lastUseTime = 0f;

    public virtual void TryUse()
    {
        if (Time.time > lastUseTime + data.Cooldown)
        {
            OnSuccessfulUse();
            lastUseTime = Time.time;
        }
    }

    public abstract void OnSuccessfulUse();
}