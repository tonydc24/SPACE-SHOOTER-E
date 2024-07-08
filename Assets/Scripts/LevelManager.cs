using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadLevel(int levelNo)
    {
        SceneManager.LoadScene(levelNo);
    }

    public void NextLevel()
    {
        int levelNo = SceneManager.GetActiveScene().buildIndex + 1;
        if (levelNo > SceneManager.sceneCountInBuildSettings - 1)
        {
            levelNo = SceneManager.sceneCountInBuildSettings - 1;
        }
        LoadLevel(levelNo);
    }
}
