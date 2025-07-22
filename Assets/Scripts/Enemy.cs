using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{   [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _targetTag = "Tower";

    [SerializeField]
    private EnemyData _enemyData;
    private Transform _target;

    private Health _targetHealth;

    private bool _isRunning;

    private void OnEnable()
    {
        _isRunning = false;
        GetTarget();
    }

    private void GetTarget()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(_targetTag);
        if (targetObject != null)
        {
            _target = targetObject.transform;
            _targetHealth = targetObject.GetComponent<Health>();
            _isRunning = true;
            _animator.Play(_enemyData._RunAnimationName);
        }
    }

    private void Update()
    {
        if (_isRunning)
        {
            transform.LookAt(_target);
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _enemyData._RunSpped * Time.deltaTime);
            if (Vector3.Distance(transform.position, _target.position) <= _enemyData._AttackRange)
            {
                _isRunning = false;
                StartCoroutine(Attack());
            }
        }

    }

    private IEnumerator Attack()
    {
        while (_target != null && _targetHealth.CurrentHealth > 0)
        {
            _animator.Play(_enemyData._AttackAnimationName, 0, 0f);
            yield return new WaitForSeconds(_enemyData._AttackDuration);
            _targetHealth.TakeDamage(_enemyData._AttackDamage);
            yield return new WaitForSeconds(_enemyData._AttackWaitTime);
        }
    }

    private void OnDisable()
    {
        _isRunning = false;
        _target = null;
        _targetHealth = null;
        StopAllCoroutines();
    }
}
