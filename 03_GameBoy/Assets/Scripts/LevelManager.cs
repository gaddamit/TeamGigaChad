using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public const int LevelCount = 3;  // Toplam seviye sayýsý
    public static int CurrentPlayingLevel { get; private set; } = 0;  // Þu an oynanan seviyenin indeksi

    public void GoNextLevel()
    {
        CurrentPlayingLevel++;

        if (CurrentPlayingLevel < LevelCount)
        {
            LoadLevel(CurrentPlayingLevel);
        }
        else
        {
            ReturnToMenu();
        }
    }

    private void LoadLevel(int levelIndex)
    {
        // Seviyeyi yükleme iþlemi
        string levelName = "Level" + (levelIndex + 1);  // Seviye ismi örneðin "Level1", "Level2", ...
        SceneManager.LoadScene(levelName);
    }

    private void ReturnToMenu()
    {
        // Menü sahnesine dönme iþlemi
        SceneManager.LoadScene("MainMenu");
    }
}
