using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Canvas menuCanvas, levelCanvas;
    public Button level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11, level12, level13, level14, level15;
    public static bool level1b, level2b, level3b, level4b, level5b, level6b, level7b, level8b, level9b, level10b, level11b, level12b, level13b, level14b, level15b;

    private void Start()
    {
        if (LaserController.canvasBool == true)
        {
            menuCanvas.gameObject.SetActive(false);
            levelCanvas.gameObject.SetActive(true);
        }
        else
        {
            menuCanvas.gameObject.SetActive(true);
            levelCanvas.gameObject.SetActive(false);
        }
        

    }
    private void Update()
    {
        Button[] levelButtons = {level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11, level12, level13, level14, level15 };
        for (int i = 1; i <= 15; i++)
        {
            if (PlayerPrefs.GetInt("Level" + i) == 1 && levelButtons[i - 1].interactable == false)
            {
                if (i - 1 > 0 && levelButtons[i - 2].interactable == true) // i-3'ü i-2 yaptým buradan tekrar kontrol et
                {
                    PlayerPrefs.SetInt("Level" + (i-1), 0);
                    levelButtons[i - 2].interactable = false;
                }

                levelButtons[i - 1].interactable = true;
                break;
            }
        }
    }
    public void PlayButton()
    {
        menuCanvas.gameObject.SetActive(false);
        levelCanvas.gameObject.SetActive(true);
    }
    public void HomeButton()
    {
        menuCanvas.gameObject.SetActive(true);
        levelCanvas.gameObject.SetActive(false);
    }
    public void GameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void UpdateLevelButton(int level)
    {
        switch (level)
        {
            case 1:
                level1b = true;
                break;
            case 2:
                level2b = true;
                level1b = false;
                break;
            case 3:
                level3b = true;
                level2b = false;
                break;
            case 4:
                level4b = true;
                level3b = false;
                break;
            case 5:
                level5b = true;
                level4b = false;
                break;
            case 6:
                level6b = true;
                level5b = false;
                break;
            case 7:
                level7b = true;
                level6b = false;
                break;
            case 8:
                level8b = true;
                level7b = false;
                break;
            case 9:
                level9b = true;
                level8b = false;
                break;
            case 10:
                level10b = true;
                level9b = false;
                break;
            case 11:
                level11b = true;
                level10b = false;
                break;
            case 12:
                level12b = true;
                level11b = false;
                break;
            case 13:
                level13b = true;
                level12b = false;
                break;
            case 14:
                level14b = true;
                level13b = false;
                break;
            case 15:
                level15b = true;
                level14b = false;
                break;
        }

    }
}

