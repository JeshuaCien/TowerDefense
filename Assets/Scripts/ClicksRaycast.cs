using UnityEngine;
using UnityEngine.Events;

public class ClicksRaycast : MonoBehaviour
{
    [SerializeField]
    private LayerMask _raycastLayerMask;

    [SerializeField]
    private string _coinTagname = "Coin";

    [SerializeField]
    private float _rayDistance = 100f;

    [SerializeField]
    private UnityEvent<Transform> _onCoinCollected;

    private bool _isActive = true;

    public bool IsActive { set => _isActive = value; }

    private void Update()
    {
        if (_isActive && Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayDistance, _raycastLayerMask))
            {
                if (hit.collider.CompareTag(_coinTagname))
                {
                    Coin coin = hit.collider.GetComponent<Coin>();
                    if (coin != null)
                    {
                        CoinCollected(coin);
                    }
                }
            }
        }
    }

    private void CoinCollected(Coin coin)
    {
        coin.Collect();
        _onCoinCollected?.Invoke(coin.transform);
    }
}
