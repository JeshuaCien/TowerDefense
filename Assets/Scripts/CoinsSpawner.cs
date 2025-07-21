using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField]
    private float _spawnInterval = 2f;

    [SerializeField]
    private float _radius = 0.5f;

    [SerializeField]
    private UnityEvent<Vector3> _spawnCoin;

    [SerializeField]
    private float _positionY = 0f;
    private Coroutine _spawnCoroutine;

    public void Initialize()
    {
        _spawnCoroutine = StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            Vector3 spawnPosition = Random.insideUnitSphere * _radius;
            spawnPosition.y = _positionY;
            _spawnCoin?.Invoke(spawnPosition);
            yield return new WaitForSeconds(_spawnInterval);  
        }
    }

    public void Stop()
    {
        if(_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
}
