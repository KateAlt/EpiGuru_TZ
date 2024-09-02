using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameUIController gameUIController;
    [SerializeField] private Player player;
    [SerializeField] private int score;
    private bool isPause = true;

    private void GameSetOff(string message)
    {
        player.SetState(false);
        gameUIController.InitMessage(message, score);
    }

    private void AddPointToScore()
    {
        score ++;
        gameUIController.InitScore(score);
    }

    private void SetGameOnPause()
    {
        if(isPause)
        {
            isPause = false;
            player.SetState(false);
        }
        else
        {
            isPause = true;
            player.SetState(true);
        }
    }

    private void OnEnable(){
        Player.GameOff += GameSetOff;
        Player.AddPoint += AddPointToScore;
        GameUIController.OnPause  += SetGameOnPause;
    }

    private void OnDisable()
    {
        Player.GameOff -= GameSetOff;
        Player.AddPoint -= AddPointToScore;
        GameUIController.OnPause -= SetGameOnPause;
    }
}
