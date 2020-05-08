using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public event Action<float> OnDamageTaken;
    public event Action OnAllHealthLost;

    private float currentHealth;

    public void SetAsMax()
    {
        currentHealth = maxHealth;
    }

    public void ChangeCurrentBy(float value)
    {
        if (currentHealth != 0)
        {
            currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);

            if (value < 0)
            {
                OnDamageTaken?.Invoke(-value);
            }

            if (currentHealth == 0)
            {
                OnAllHealthLost?.Invoke();
            }
        }
    }
}