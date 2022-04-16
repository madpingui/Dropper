using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text score, hiscore;

    public Text coinsText;
    private int coins;

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();

        hiscore.text = PlayerPrefs.GetInt("Hiscore").ToString();
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        score.text = Time.timeSinceLevelLoad.ToString("0");
    }

    public void RestartGame()
    {
        Invoke("RestartAfterTime", 1f);
    }

    void RestartAfterTime()
    {
        PlayerPrefs.SetInt("Coins", coins);
        if (Time.timeSinceLevelLoad > PlayerPrefs.GetInt("Hiscore"))
        {
            PlayerPrefs.SetInt("Hiscore", (int)Time.timeSinceLevelLoad);
        }
        SceneManager.LoadScene("GamePlay");
    }

    public void addCoin()
    {
        coins++;
        coinsText.text = coins.ToString();
    }
}
