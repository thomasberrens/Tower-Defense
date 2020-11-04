using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MultiTargetTower : Tower<Enemy[]>
{
    public UnityEvent MultiAttackEvent;
    protected override bool CanAttack()
    {
        _target = _rangeChecker.GetAllEnemiesInRange();
        if (_target == null || _target.Length < 1) return false;

        return true;
    }

    protected override void Attack()
    {
        foreach (Enemy enemy in _target)
        {
            print("multi target attack at: " + enemy.name);
            MultiAttackEvent?.Invoke();
            enemy._health.TakeDamage(0.08f);
            
        }
    }

}
