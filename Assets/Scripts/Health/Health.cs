﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Serializable]
    public class OnTakeDamageEvent : UnityEvent<Health> {}
    [SerializeField] private float _startHealth = 3;
    
    public OnTakeDamageEvent OnTakeDamage;
    public UnityEvent OnDeathEvent;
    

    private float _currentHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _startHealth;
    }

    // Called from UnityEvent
    public void TakeDamage(float dmg)
    {
        _currentHealth = Mathf.Max(_currentHealth - dmg, 0);
        OnTakeDamage?.Invoke(this);
        
        if (_currentHealth <= 0)
        {
            OnDeathEvent?.Invoke();
        }
    }

    public float GetNormalizedHealth()
    {
        return _currentHealth / _startHealth;
    }
}
