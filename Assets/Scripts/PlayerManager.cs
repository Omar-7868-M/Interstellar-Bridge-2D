using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    PlayerController script;
    public GameObject[] playerPrefabs;
    int characterIndex;
    public GameObject startPoint;
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public CinemachineVirtualCamera VCam;

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    public GameObject pauseMenuScreen;



    private void Awake() 
    {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate (playerPrefabs[characterIndex], startPoint.transform.position, Quaternion.identity);
        VCam.m_Follow = player.transform;//follow player

        isGameOver = false;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);

        }
        
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
