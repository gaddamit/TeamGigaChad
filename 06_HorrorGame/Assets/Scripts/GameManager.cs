using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private TMP_Text _keysCollectedText;
    [SerializeField] private int _keysToCollect = 8;
    private int _collectedKeys = 0;
    public bool AreKeysCollected => _keysToCollect == _collectedKeys;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCollectedKey()
    {
        _collectedKeys++;
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void UpdateUI()
    {
        _keysCollectedText.text = $"Keys: {_collectedKeys}/{_keysToCollect}";
    }
}
