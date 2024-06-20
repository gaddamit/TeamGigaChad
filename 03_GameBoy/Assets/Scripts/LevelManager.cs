using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public const int LevelCount = 3;  // Toplam seviye say�s�
    public static int CurrentPlayingLevel { get; private set; } = 0;  // �u an oynanan seviyenin indeksi

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
        // Seviyeyi y�kleme i�lemi
        string levelName = "Level" + (levelIndex + 1);  // Seviye ismi �rne�in "Level1", "Level2", ...
        SceneManager.LoadScene(levelName);
    }

    private void ReturnToMenu()
    {
        // Men� sahnesine d�nme i�lemi
        SceneManager.LoadScene("MainMenu");
    }
}
