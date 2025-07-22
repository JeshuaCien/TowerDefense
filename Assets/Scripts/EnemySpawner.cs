using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float _secondsToSpawn = 5f;

    [SerializeField]
    private float _radius = 0.5f;

    [SerializeField]
    private UnityEvent<Vector3> _spawnEnemy;

    public void Initialized()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector2 direction = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = new Vector3(direction.x, 0, direction.y) * _radius;
            _spawnEnemy?.Invoke(spawnPosition);
            yield return new WaitForSeconds(_secondsToSpawn);
        }
    }
}
