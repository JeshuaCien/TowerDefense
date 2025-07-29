using UnityEngine;
using UnityEngine.Events;

public class CoinsNumber : MonoBehaviour
{
    [SerializeField]
    private int _coins;
    public int Coins { get => _coins; }

    [SerializeField]
    private UnityEvent<int> _onCoinsUpdated;

    [SerializeField]
    private UnityEvent _onBuySucces;

    [SerializeField]
    private UnityEvent _OnbuyFail;

    public void AddCoins(int amount)
    {
        _coins += amount;
        SetCoins(_coins);
    }

    public void SetCoins(int amount)
    {
        _coins = amount;
        _onCoinsUpdated?.Invoke(_coins);
    }

    public void SubstracCoins(int amount)
    {
        _coins -= amount;
        if (_coins < 0) _coins = 0;
        SetCoins(_coins);
    }

    public bool BuyObject(int cost)
    {
        if (_coins >= cost)
        {
            SubstracCoins(cost);
            _onBuySucces?.Invoke();
            return true;
        }
        else
        {
            _OnbuyFail?.Invoke();
            return false;
        }
    }
    
}
