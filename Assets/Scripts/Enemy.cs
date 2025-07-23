using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{ [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _targetTag = "Tower";

    [SerializeField]
    private UnityEvent _onIntialized;
    private Vector3 _targetPosition;

    [SerializeField]
    private EnemyData _enemyData;

    private Health _targetHealth;

    private bool _isRunning;

    private void OnEnable()
    {
        _onIntialized?.Invoke();
        _isRunning = false;
        Invoke("GetTarget", 0.5f);
    }

    private void GetTarget()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(_targetTag);
        if (targetObject != null)
        {
            _targetPosition = new Vector3(targetObject.transform.position.x, transform.position.y, targetObject.transform.position.z);
            _targetHealth = targetObject.GetComponent<Health>();
            _isRunning = true;
            _animator.Play(_enemyData._RunAnimationName);
        }
    }

    private void Update()
    {
        if (_isRunning)
        {
            transform.LookAt(_targetPosition);
            Vector3 movePosition = Vector3.MoveTowards(transform.position, _targetPosition, _enemyData._RunSpped * Time.deltaTime);
            transform.position = movePosition;
            if (Vector3.Distance(transform.position, _targetPosition) <= _enemyData._AttackRange)
            {
                _isRunning = false;
                StartCoroutine(Attack());
            }
        }

    }

    private IEnumerator Attack()
    {
        while (_targetHealth != null && _targetHealth.CurrentHealth > 0)
        {
            _animator.Play(_enemyData._AttackAnimationName, 0, 0f);
            yield return new WaitForSeconds(_enemyData._AttackDuration);
            _targetHealth.TakeDamage(_enemyData._AttackDamage);
            yield return new WaitForSeconds(_enemyData._AttackWaitTime);
        }
        Win();
    }

    private void Win()
    {
        _animator.Play(_enemyData._WinAnimationName);
        _isRunning = false;
    }

    public void Die()
    {
        _isRunning = false;
        StopAllCoroutines();
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        _animator.Play(_enemyData._DeathAnimationName);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        _isRunning = false;
        _targetHealth = null;
        StopAllCoroutines();
    }
}
