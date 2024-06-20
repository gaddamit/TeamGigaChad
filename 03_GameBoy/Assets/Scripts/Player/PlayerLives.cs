using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int Lives { get; set; } = 3;
    public Image[] hearts;
    public Sprite fullLives;
    public Sprite emptyLives; 

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyLives;
        }
        for (int i = 0; i < Lives; i++)
        {
            hearts[i].sprite = fullLives;
        }
    }
}
