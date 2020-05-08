using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float minDamage;
    [SerializeField] protected float maxDamage;
    [SerializeField] protected float cooldown;
    [SerializeField] protected float range;

    [SerializeField] private GameObject body;
    public GameObject Body { get { return body; } }

    [SerializeField] private Sprite spriteUI;
    public Sprite SpriteUI { get { return spriteUI; } }

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