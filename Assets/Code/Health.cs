using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float MaxHealth { get { return maxHealth; } }

    public event Action OnHealthChanged;
    public event Action OnAllHealthLost;

    public float CurrentHealth { get; private set; }

    public void SetAsMax()
    {
        CurrentHealth = maxHealth;
        OnHealthChanged?.Invoke();
    }

    public void ChangeCurrentBy(float value)
    {
        if (CurrentHealth != 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, maxHealth);

            if (value != 0)
            {
                OnHealthChanged?.Invoke();
            }

            if (CurrentHealth == 0)
            {
                OnAllHealthLost?.Invoke();
            }
        }
    }
}