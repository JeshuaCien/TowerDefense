using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GunData _gunData;

    //[SerializeField]
    private GameObject _shootParticles;

    [SerializeField]
    private Transform _turret;

    private EnemyTarget _target;

    private void OnTriggerStay(Collider other)
    {
        if (_target == null && other.CompareTag("Enemy") && other.TryGetComponent<Health>(out Health health))
        {
            _target = new EnemyTarget(other.transform, health);
            StartCoroutine(Shoot());

        }
    }

    private IEnumerator Shoot()
    {
        while (_target != null && _target.Health.CurrentHealth > 0)
        {
            SoundManager.instance.Play(_gunData.shootSoundName);
            _target.Health.TakeDamage(_gunData.damage);
            ShowParticles(_target.Target);
            yield return new WaitForSeconds(_gunData.fireRate);
        }
        _target = null;
    }

    private void ShowParticles(Transform target)
    {
        if (_shootParticles == null)
        {
            _shootParticles = Instantiate(_gunData.shootParticlesPrefab, target.position, Quaternion.identity);
        }
        else
        {
            _shootParticles.SetActive(false);
            _shootParticles.transform.SetPositionAndRotation(target.position, Quaternion.identity);
            _shootParticles.SetActive(true);
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            _turret.LookAt(_target.Target);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        _target = null;
    }
}
