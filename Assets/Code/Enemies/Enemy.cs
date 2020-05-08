using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health health;

    public bool Initialized { get; private set; }

    private GameObjectPool enemyPool;

    public void Init(GameObjectPool enemyPool)
    {
        this.enemyPool = enemyPool;
        health.OnAllHealthLost += OnAllHealthLost;
        Initialized = true;
    }

    private void OnAllHealthLost()
    {
        enemyPool.Return(this.gameObject);
    }
}