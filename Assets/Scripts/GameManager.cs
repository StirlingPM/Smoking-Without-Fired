using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static bool isSeen,isSmoking;
    public static Text scoreText;
    public static CurrentGameState gameState = CurrentGameState.PreGame;
    public GameObject menu, hud, gameOver;
    public void UIScreens(bool x, bool y, bool z)
    {
        menu.SetActive(x);
        hud.SetActive(y);
        gameOver.SetActive(z);

    }
    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        UIScreens(true, false, false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartGame()
    {
        isSeen = false;
        UIScreens(false, true, false);
        gameState = CurrentGameState.Game;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    public void Restart(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    private void Update()
    {
        if (gameState == CurrentGameState.Game)
        {
            if ((isSeen && isSmoking) || Input.GetKeyDown(KeyCode.Alpha0))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                UIScreens(false, true, true);
                gameState = CurrentGameState.PostGame;

            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
public enum CurrentGameState
{
    PreGame,
    Game,
    PostGame
}