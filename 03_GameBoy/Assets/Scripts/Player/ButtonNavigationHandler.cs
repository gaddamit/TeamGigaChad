using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNavigationHandler : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons = new List<Button>();

    private int _buttonCount = 0;
    private Button _selectedButton;
    private int _selectedIndex = 0;

    private void Start()
    {
        _buttonCount = _buttons.Count;

        if (_buttonCount == 0)
        {
            Debug.LogWarning("Hiç button yok!");
            return;
        }

        _selectedButton = _buttons[0];
        SelectButton(_selectedIndex);  // Baþlangýçta ilk butonu seç
    }

    private void Update()
    {
        HandleInput();
    }

    private void SelectButton(int index)
    {
        // Tüm butonlarýn rengini varsayýlan hale getir
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].gameObject.GetComponent<Image>().color = new Color(0,0,0,0.54f);  // Buton rengi varsayýlan
        }

        // Yeni butonu seç ve rengini deðiþtir
        _selectedIndex = index;
        _selectedButton = _buttons[_selectedIndex];
        _selectedButton.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);  // Seçilen buton rengi kýrmýzý
        _selectedButton.Select();  // Butonun gerçekten seçili olmasý için UI sistemine bildir
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _selectedIndex--;
            if (_selectedIndex < 0)
            {
                _selectedIndex = _buttonCount - 1;
            }
            SelectButton(_selectedIndex);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _selectedIndex++;
            if (_selectedIndex >= _buttonCount)
            {
                _selectedIndex = 0;
            }
            SelectButton(_selectedIndex);
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            _selectedButton.onClick.Invoke();
        }
    }
}
