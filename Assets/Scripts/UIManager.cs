using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<Animator> _buttons;

    [SerializeField]
    private string _buttonAppear = "UIObjectAppear";

    [SerializeField]
    private string _buttonDisappear = "UIObjectDisappear";

    public void ShowButtons()
    {
        foreach (Animator button in _buttons)
        {
            button.Play(_buttonAppear);
        }
    }

    public void HideButtons()
    {
        foreach (Animator button in _buttons)
        {
            button.Play(_buttonDisappear);
        }
    }

}
