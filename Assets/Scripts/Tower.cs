using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField]

    private Health _health;

    public Health Health => _health;
    [SerializeField]
    private UnityEvent _onStart;

    public void Initialize()
    {
        _onStart?.Invoke();
    }
}
