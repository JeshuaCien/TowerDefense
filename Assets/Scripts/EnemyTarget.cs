using UnityEngine;

public class EnemyTarget
{
    private Transform _target;

    public Transform Target => _target;

    private Health _health;

    public Health Health => _health;

    public EnemyTarget(Transform target, Health health)
    {
        _target = target;
        _health = health;
    }
}
