using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
   [SerializeField]
   private Text _coinText;

   [SerializeField]
   private UnityEvent _onCoinsUpdated;

   public void UpadteCoins(int coins)
   {
    _coinText.text = "x" + coins.ToString();
    _onCoinsUpdated?.Invoke();
   }
}
