using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SinglePlayerGameOver : MonoBehaviour
{
    [SerializeField] private SinglePlayerUIManager singlePlayerUIManager;

    [SerializeField] private Button restartButton, mainmenuButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(Restart);
        mainmenuButton.onClick.AddListener(MainMenu);
    }

    private void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
