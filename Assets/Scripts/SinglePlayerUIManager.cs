using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreBoostUI;
    [SerializeField] private GameObject speedUI;
    [SerializeField] private GameObject shieldUI;

    [SerializeField] private Snake snake;

    private void Update()
    {
        PowerUpUI();
    }

    private void PowerUpUI()
    {
        if (snake.GetScoreActive())
        {
            scoreBoostUI.SetActive(true);
            speedUI.SetActive(false);
            shieldUI.SetActive(false);
        }
        else
        {
            scoreBoostUI.SetActive(false);
        }

        if (snake.GetShieldActive())
        {
            shieldUI.SetActive(true);
            scoreBoostUI.SetActive(false);
            speedUI.SetActive(false);
        }
        else
        {
            shieldUI.SetActive(false);
        }

        if (snake.GetSpeedActive())
        {
            speedUI.SetActive(true);
            scoreBoostUI.SetActive(false);
            shieldUI.SetActive(false);
        }
        else
        {
            speedUI.SetActive(false);
        }
    }

    public void SetGameobjectActive(bool r)
    {
        shieldUI.SetActive(r);
    }
}
